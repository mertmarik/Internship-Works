import tkinter as tk
import tkinter.ttk as ttk
from tkinter import scrolledtext, messagebox
import os
import time
import google.generativeai as genai

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

class ChatGUI:
    def __init__(self, root):
        self.root = root
        self.root.title("TALAI")
        self.root.configure(bg="#2f2f2f")  # dark gray background

        # Create a main frame with a grid layout
        self.main_frame = tk.Frame(root, bg="#2f2f2f")
        self.main_frame.grid(row=0, column=0, padx=10, pady=10, sticky=tk.NSEW)

        # Create a chat history frame with a scrolled text widget
        self.chat_history_frame = tk.Frame(self.main_frame, bg="#2f2f2f")
        self.chat_history_frame.grid(row=0, column=0, padx=10, pady=10, sticky=tk.NSEW)
        self.chat_history = scrolledtext.ScrolledText(self.chat_history_frame, width=60, height=20, wrap=tk.WORD, bg="#6b6868", fg="#fff")
        self.chat_history.grid(row=0, column=0, padx=10, pady=10, sticky=tk.NSEW)

        # Create a input frame with an entry widget and buttons
        self.input_frame = tk.Frame(self.main_frame, bg="#2f2f2f")
        self.input_frame.grid(row=1, column=0, padx=10, pady=10, sticky=tk.NSEW)

        self.input_entry = tk.Entry(self.input_frame, width=55, bg="#7a7878", fg="#fff", font=("Helvetica", 12, "bold"))
        self.input_entry.grid(row=0, column=0, padx=10, pady=10, sticky=tk.EW)

        self.input_button_frame = tk.Frame(self.input_frame, bg="#2f2f2f")
        self.input_button_frame.grid(row=1, column=0, padx=10, pady=10)

        self.send_button = tk.Button(self.input_button_frame, text="Gönder", command=self.send_message, bg="#4CAF50", fg="#fff", font=("Helvetica", 11, "bold"))
        self.send_button.grid(row=0, column=0, padx=10, pady=10)

        self.end_button = tk.Button(self.input_button_frame, text="Çıkış", command=self.end_message, bg="#F44336", fg="#fff", font=("Helvetica", 11, "bold"))
        self.end_button.grid(row=0, column=1, padx=10, pady=10)

        self.input_entry.delete(0, tk.END)

                
        # Initialize chat session
        self.chat_session = None
        self.initialize_chat_session()

    def initialize_chat_session(self):
        # Initialize your chat session here
        global model
        self.chat_session = model.start_chat(
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

    def send_message(self):
        user_message = self.input_entry.get()
        if user_message.strip() == "":
            return

        # Display user message on the right side
        user_message_frame = ttk.Frame(self.chat_history, style='User.TFrame')
        user_message_label = ttk.Label(user_message_frame, text="Siz: " + user_message, style='User.TLabel', wraplength=300, justify=tk.RIGHT)
        user_message_label.pack(ipadx=5, ipady=5, anchor='e')

        self.chat_history.configure(state=tk.NORMAL)
        self.chat_history.window_create(tk.END, window=user_message_frame)
        self.chat_history.insert(tk.END, '\n')
        self.chat_history.configure(state=tk.DISABLED)
        self.chat_history.see(tk.END)

        response = self.send_message_to_model(user_message)

        # Display model response on the left side
        model_response_frame = ttk.Frame(self.chat_history, style='Model.TFrame')
        model_response_label = ttk.Label(model_response_frame, text="TalAI: " + response, style='Model.TLabel', wraplength=300, justify=tk.LEFT)
        model_response_label.pack(ipadx=5, ipady=5, anchor='w')

        self.chat_history.configure(state=tk.NORMAL)
        self.chat_history.window_create(tk.END, window=model_response_frame)
        self.chat_history.insert(tk.END, '\n')
        self.chat_history.configure(state=tk.DISABLED)
        self.chat_history.see(tk.END)

        self.input_entry.delete(0, tk.END)
    
    def send_message_to_model(self, message):
        response = self.chat_session.send_message(message)
        return response.text
    
    def end_message(self):
        self.root.destroy()

def main():
    root = tk.Tk()
    
    # Set background color for the root window
    root.configure(bg="#E5DDD5")
    
    # Define styles for user and model messages
    style = ttk.Style()
    style.configure('User.TFrame', background='#DCF8C6', foreground='black')
    style.configure('Model.TFrame', background='#C7CEEA', foreground='black')
    style.configure('User.TLabel', foreground='black', wraplength=300, background='#DCF8C6', font=('Helvetica', 12, 'italic'), justify=tk.RIGHT)
    style.configure('Model.TLabel', foreground='black', wraplength=300, background='#C7CEEA', font=('Helvetica', 12, 'italic'), justify=tk.LEFT)
    
    app = ChatGUI(root)
    root.mainloop()

if __name__ == "__main__":
    files = [
        upload_to_gemini(r"Takasbank.csv", mime_type="text/csv"),
    ]
    wait_for_files_active(files)
    main()
