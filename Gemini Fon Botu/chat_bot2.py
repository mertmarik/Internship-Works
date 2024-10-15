from tkinter import ttk
import os
import time
import google.generativeai as genai
import tkinter as tk


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

# Kullanıcı mesajlarını gönderme ve cevap alma fonksiyonu
def send_message_to_model(message):
    response = chat_session.send_message(message)
    return response.text

class ScrollableFrame(ttk.Frame):
    def __init__(self, container, *args, **kwargs):
        super().__init__(container, *args, **kwargs)
        self.canvas = tk.Canvas(self)
        scrollbar = ttk.Scrollbar(self, orient="vertical", command=self.canvas.yview)
        self.scrollable_frame = ttk.Frame(self.canvas)

        self.scrollable_frame.bind(
            "<Configure>",
            lambda e: self.canvas.configure(
                scrollregion=self.canvas.bbox("all")
            )
        )

        self.canvas.create_window((0, 0), window=self.scrollable_frame, anchor="nw")
        self.canvas.configure(yscrollcommand=scrollbar.set)

        self.canvas.pack(side="left", fill="both", expand=True)
        scrollbar.pack(side="right", fill="y")

    def scroll_to_bottom(self):
        self.canvas.yview_moveto(1)

# Tkinter arayüzü
class ChatApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Fon Danışmanı - TALAI")
        self.root.geometry("1920x1080")
        self.root.configure(bg="#1f3b6a")

        self.chat_frame_container = ScrollableFrame(self.root)
        self.chat_frame_container.pack(pady=20, padx=20, fill=tk.BOTH, expand=True, anchor="center")
        self.chat_frame = self.chat_frame_container.scrollable_frame

        self.entry_box = tk.Entry(self.root, bg="#d3d3d3", font=("Arial", 14))
        self.entry_box.pack(pady=10, padx=20, fill=tk.X, side=tk.LEFT, expand=True)

        self.send_button = tk.Button(self.root, text="Gönder", command=self.send_message, bg="#4b0082", fg="white", font=("Arial", 14))
        self.send_button.pack(pady=10, padx=20, side=tk.LEFT)

    def send_message(self):
        user_message = self.entry_box.get()
        self.entry_box.delete(0, tk.END)
        self.update_chat("Siz", user_message, "right")  # Sağa yasla

        response = send_message_to_model(user_message)
        self.update_chat("Gemini", response, "left")  # Sola yasla

    def update_chat(self, sender, message, align):
        frame = tk.LabelFrame(self.chat_frame, bg="#1f3b6a", padx=10, pady=5)
        frame.anchor = "center"
        frame.pack(pady=5, padx=20, fill=tk.X, expand=True, anchor='e' if align == "right" else 'w')

        message_label = tk.Label(frame, text=message, bg='#1f3b6a', fg="white", font=("Arial", 12), wraplength=400, padx=10, pady=5, anchor='w' if align == "right" else 'e')
        message_label.pack(fill=tk.X)

        sender_label = tk.Label(frame, text=sender, bg="#1f3b6a", fg="white", font=("Arial", 8))
        sender_label.pack(anchor='e' if align == "right" else 'w')

        self.chat_frame_container.update_idletasks()
        self.chat_frame_container.scroll_to_bottom()

root = tk.Tk()
app = ChatApp(root)
root.mainloop()

