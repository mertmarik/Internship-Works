import 'dart:developer';
import 'package:flutter/material.dart';
//import 'package:gemini_gpt/gemini_api.dart';
import 'package:gemini_gpt/message.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:gemini_gpt/profile/profile_page.dart';
import 'package:gemini_gpt/theme_notifier.dart';
import 'package:google_generative_ai/google_generative_ai.dart';

class MyHomePage extends ConsumerStatefulWidget {
  const MyHomePage({super.key});

  @override
  ConsumerState<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends ConsumerState<MyHomePage> {
  final TextEditingController _controller = TextEditingController();
  final List<Message> _messages = [];
  bool _isLoading = false;
  final ScrollController _scrollController = ScrollController();
  @override
  void dispose() {
    _scrollController.dispose();
    _controller.dispose();
    super.dispose();
  }

  void _clearMessage() {
    setState(() {
      _messages.clear();
    });
  }

  void _sendMessage() async {
    try {
      final messageText = _controller.text.trim();
      if (messageText.isEmpty) return;
      _controller.clear();
      setState(() {
        _messages.add(Message(text: messageText, isUser: true));
        _isLoading = true; // Set loading state when sending message
      });
      _scrollToBottom();
      final model = GenerativeModel(
          model: 'gemini-pro',
          apiKey: '');
      final content = [Content.text(messageText)];
      final response = await model.generateContent(content);

      setState(() {
        _messages.add(Message(text: response.text!, isUser: false));
        _isLoading = false; // Clear loading state after receiving response
      });
      _scrollToBottom();
      _controller.clear();
    } catch (e) {
      log("Error : $e");
      setState(() {
        _isLoading = false; // Ensure loading state is cleared on error
      });
    }
  }

  void _scrollToBottom() {
    _scrollController.animateTo(
      _scrollController.position.maxScrollExtent,
      duration: const Duration(milliseconds: 300),
      curve: Curves.easeOut,
    );
  }

  @override
  Widget build(BuildContext context) {
    final currentTheme = ref.watch(themeProvider);

    return Scaffold(
      backgroundColor:
          (currentTheme == ThemeMode.light) ? Colors.white : Colors.black,
      appBar: AppBar(
        centerTitle: false,
        backgroundColor: (currentTheme == ThemeMode.light)
            ? const Color.fromARGB(103, 255, 255, 255)
            : const Color.fromARGB(28, 0, 0, 0),
        elevation: 1,
        title: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Row(
              children: [
                (currentTheme == ThemeMode.dark)
                    ? GestureDetector(
                        onTap: () {},
                        child: Icon(Icons.message_sharp,
                            color: Theme.of(context).colorScheme.secondary),
                      )
                    : GestureDetector(
                        onTap: () {},
                        child: Icon(Icons.message_sharp,
                            color: Theme.of(context).colorScheme.primary),
                      ),
                const SizedBox(
                  width: 10,
                ),
                Text(
                  'YAP-AI',
                  style: Theme.of(context).textTheme.titleLarge,
                )
              ],
            ),
            Expanded(child: Container()), // Boş alan oluşturur
            GestureDetector(
              onTap: _clearMessage,
              child: (currentTheme == ThemeMode.dark)
                  ? const Icon(
                      Icons.clear_sharp,
                      color: Color.fromARGB(255, 136, 22, 14),
                      size: 35,
                    )
                  : const Icon(
                      Icons.clear_sharp,
                      color: Color.fromARGB(255, 136, 22, 14),
                      size: 35,
                    ),
            ),
            const SizedBox(width: 10), // İkonlar arasına boşluk ekler
            GestureDetector(
              child: (currentTheme == ThemeMode.dark)
                  ? const Icon(
                      Icons.light_mode,
                      color: Colors.yellow,
                    )
                  : Icon(
                      Icons.dark_mode,
                      color: Theme.of(context).iconTheme.color,
                    ),
              onTap: () {
                ref.read(themeProvider.notifier).toggleTheme();
              },
            ),
            IconButton(
              onPressed: () {
                Navigator.pushAndRemoveUntil(
                    context,
                    MaterialPageRoute(
                        builder: (context) => const ProfilePage()),
                    (route) => false);
              },
              icon: const Icon(Icons.person),
            )
          ],
        ),
      ),
      body: Column(
        children: [
          Expanded(
            child: ListView.builder(
              controller: _scrollController,
              itemCount: _messages.length,
              itemBuilder: (context, index) {
                final message = _messages[index];
                return ListTile(
                  title: Align(
                    alignment: message.isUser
                        ? Alignment.centerRight
                        : Alignment.centerLeft,
                    child: Container(
                      padding: const EdgeInsets.all(10),
                      decoration: BoxDecoration(
                        color: message.isUser
                            ? Theme.of(context).colorScheme.primary
                            : Theme.of(context).colorScheme.secondary,
                        borderRadius: message.isUser
                            ? const BorderRadius.only(
                                topLeft: Radius.circular(20),
                                bottomRight: Radius.circular(20),
                                bottomLeft: Radius.circular(20),
                              )
                            : const BorderRadius.only(
                                topRight: Radius.circular(20),
                                topLeft: Radius.circular(20),
                                bottomRight: Radius.circular(20),
                              ),
                      ),
                      child: Text(
                        message.text,
                        style: message.isUser
                            ? Theme.of(context).textTheme.bodyMedium
                            : Theme.of(context).textTheme.bodyMedium,
                      ),
                    ),
                  ),
                );
              },
            ),
          ),

          // User input
          Padding(
            padding: const EdgeInsets.only(
                bottom: 32, top: 16.0, left: 16.0, right: 16),
            child: Container(
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(32),
                boxShadow: [
                  BoxShadow(
                    color: Colors.grey.withOpacity(0.5),
                    spreadRadius: 5,
                    blurRadius: 7,
                    offset: const Offset(0, 3),
                  ),
                ],
              ),
              child: Row(
                children: [
                  Expanded(
                    child: TextField(
                      controller: _controller,
                      style: Theme.of(context).textTheme.titleSmall,
                      decoration: InputDecoration(
                        hintText: 'Mesajınızı Yazınız',
                        hintStyle: Theme.of(context)
                            .textTheme
                            .titleSmall!
                            .copyWith(color: Colors.grey),
                        border: InputBorder.none,
                        contentPadding:
                            const EdgeInsets.symmetric(horizontal: 20),
                      ),
                      maxLines: null, // Allow multi-line input
                      onSubmitted: (_) => _sendMessage(),
                    ),
                  ),
                  const SizedBox(width: 8),
                  _isLoading
                      ? const Padding(
                          padding: EdgeInsets.all(16.0),
                          child: SizedBox(
                            width: 24,
                            height: 24,
                            child: CircularProgressIndicator(),
                          ),
                        )
                      : GestureDetector(
                          onTap: _sendMessage,
                          child: Padding(
                            padding: const EdgeInsets.all(16.0),
                            child: Image.asset('assets/send.png'),
                          ),
                        ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
