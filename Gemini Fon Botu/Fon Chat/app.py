from flask import Flask, render_template, request, jsonify
import google.generativeai as genai
import os
import time

app = Flask(__name__)

# API anahtarınızı ortam değişkeni olarak ayarlayın
os.environ["GEMINI_API_KEY"] = "AIzaSyDP-HtHfjpz71rBnwJ8jwoT6gHqPRoFk1U"
genai.configure(api_key=os.environ["GEMINI_API_KEY"])

def upload_to_gemini(path, mime_type=None):
    """Uploads the given file to Gemini."""
    file = genai.upload_file(path, mime_type=mime_type)
    print(f"Uploaded file '{file.display_name}' as: {file.uri}")
    return file

def wait_for_files_active(files):
    """Waits for the given files to be active."""
    print("Waiting for file processing...")
    for name in (file.name for file in files):
        file = genai.get_file(name)
        while file.state.name == "PROCESSING":
            print(".", end="", flush=True)
            time.sleep(10)
            file = genai.get_file(name)
        if file.state.name != "ACTIVE":
            raise Exception(f"File {file.name} failed to process")
    print("...all files ready")
    print()

# Dosyaları yükleyin (dosya yollarını güncelleyin)
files = [
    upload_to_gemini(r"Takasbank.csv", mime_type="text/csv"),
]

# Dosyaların işlenmesini bekleyin
wait_for_files_active(files)

# Modeli oluşturun
generation_config = {
    "temperature": 1,
    "top_p": 0.95,
    "top_k": 64,
    "max_output_tokens": 8192,
    "response_mime_type": "text/plain",
}

model = genai.GenerativeModel(
    model_name="gemini-1.5-flash",
    generation_config=generation_config,
)

# Chat oturumu başlatın
chat_session = model.start_chat(
    history=[
        {
            "role": "user",
            "parts": [
                files[0],
                "sen kişiye özel bir yatırım danışmanısın sana yüklediğimiz veriler doğrultusunda yatırım ve fon ile ilgili sorulan soruları ceveplarsın bu sorular her şeyle alakalı olabilir önemli olan sadece sana yüklediğimiz fonlar ile alakalı olması , yüklediğimiz veriler ile alakasız soruları Bilmiyorum diyerek cevapla. Şimdi sana örnek bir soru söyleyeceğim \"Bana TLC Fonunun son bir aylık getirisini söyler misin?\" bu soruyu gördüğünde sana yüklediğimiz verilere giderek TLC Fonunu bulup ve istenilen cevabı getirirsin. Örneğin şöyle bir soru gelirse \"Bugün hava durumu nedir?\" cevap olarak Bilmediğini yaratıcı bir dille söyleyebilirsin",
            ],
        },
        {
            "role": "model",
            "parts": [
                "Anlaşıldı! Bana yüklediğiniz fon verilerine göre yatırım ve fonlarla ilgili soruları cevaplayabilirim. Veriler dışında kalan sorular için yaratıcı bir şekilde \"Bilmiyorum\" cevabını vereceğim. \n\nÖrnek sorunuz \"Bana TLC Fonunun son bir aylık getirisini söyler misin?\" için, verilerimi kontrol edip TLC Fonu'nun son bir aylık getirisini size hemen bildiririm. \"Bugün hava durumu nedir?\" gibi alakasız bir soru için ise yaratıcılığımı konuştururum. Belki \"Üzgünüm, ben sadece finansal iklimlerde uzmanım, meteorolojik konularda bilgim yok.\" gibi bir cevap verebilirim.  \n\nSorularınızı bekliyorum! 😊 \n",
            ],
        },
    ]
)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/send_message', methods=['POST'])
def send_message():
    user_message = request.json['message']
    response = chat_session.send_message(user_message)
    return jsonify({'response': response.text})

if __name__ == '__main__':
    app.run(debug=True)
