import 'package:flutter/material.dart';
import 'package:gemini_gpt/my_home_page.dart';
import 'package:gemini_gpt/signin/my_textfield.dart';
import 'package:gemini_gpt/signin/signin_button.dart';
import 'package:gemini_gpt/signin/square_tile.dart';

class Onboarding extends StatelessWidget {
  Onboarding({super.key});
  final userNameController = TextEditingController();
  final passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    void signUserIn() {
      if (userNameController.text == "mert" &&
          passwordController.text == "1234") {
        Navigator.pushAndRemoveUntil(
            context,
            MaterialPageRoute(builder: (context) => const MyHomePage()),
            (route) => false);
      } else {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(
            content: Center(
              child: Text("Wrong Username or Password"),
            ),
            duration: Duration(seconds: 2),
          ),
        );
      }
    }

    //var isDark = MediaQuery.of(context).platformBrightness == Brightness.dark;
    return Scaffold(
      backgroundColor: Colors.grey[300],
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          const SizedBox(
            height: 50,
          ),
          const Icon(Icons.lock, size: 100),
          const SizedBox(
            height: 50,
          ),
          Text(
            "Welcome to YAP-AI",
            style: TextStyle(
              color: Colors.grey[700],
              fontSize: 16,
            ),
          ),
          const SizedBox(
            height: 25,
          ),
          MyTextfield(
            controller: userNameController,
            hintText: "Username",
            obscureText: false,
          ),
          const SizedBox(height: 30),
          MyTextfield(
            controller: passwordController,
            hintText: "Password",
            obscureText: true,
          ),
          const SizedBox(
            height: 10,
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 25.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                Text(
                  "Forgot Password?",
                  style: TextStyle(
                    color: Colors.grey[600],
                  ),
                ),
              ],
            ),
          ),
          const SizedBox(
            height: 25,
          ),
          SigninButton(
            onTap: signUserIn,
          ),
          const SizedBox(
            height: 50,
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 25.0),
            child: Row(
              children: [
                Expanded(
                  child: Divider(
                    thickness: 0.5,
                    color: Colors.grey[400],
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 18.0),
                  child: Text("Or Continue With",
                      style: TextStyle(color: Colors.grey[700])),
                ),
                Expanded(
                  child: Divider(
                    thickness: 0.5,
                    color: Colors.grey[400],
                  ),
                ),
              ],
            ),
          ),
          const SizedBox(
            height: 50,
          ),
          const Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              SquareTile(imagePath: "assets/google.png"),
              SizedBox(
                width: 10,
              ),
              SquareTile(imagePath: "assets/apple.png"),
            ],
          ),
          const SizedBox(
            height: 50,
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                "Not a member?",
                style: TextStyle(color: Colors.grey[700]),
              ),
              const SizedBox(
                width: 4,
              ),
              const Text(
                "Register!",
                style:
                    TextStyle(color: Colors.blue, fontWeight: FontWeight.bold),
              ),
            ],
          ),
        ],
      ),
    );
  }
}
