import 'package:flutter/material.dart';

class MyTextfield extends StatelessWidget {
  const MyTextfield(
      {super.key,
      required this.controller,
      required this.hintText,
      required this.obscureText});
  final controller;
  final String hintText;
  final bool obscureText;
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(
        horizontal: 25.0,
      ),
      child: TextField(
        controller: controller,
        obscureText: obscureText,
        decoration: InputDecoration(
          enabledBorder: const OutlineInputBorder(
            borderSide: BorderSide(color: Colors.white),
          ),
          focusedBorder: const OutlineInputBorder(
            borderSide: BorderSide(
              color: Color.fromARGB(255, 190, 190, 190),
            ),
          ),
          fillColor: Color.fromARGB(255, 255, 255, 255),
          filled: true,
          hintText: hintText,
          hintStyle: TextStyle(
            color: Colors.grey[500],
          ),
        ),
      ),
    );
  }
}
