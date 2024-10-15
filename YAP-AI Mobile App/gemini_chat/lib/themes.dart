import 'package:flutter/material.dart';

class FontSizes {
  static const extraSmall = 14.0;
  static const small = 16.0;
  static const standard = 18.0;
  static const large = 20.0;
  static const extraLarge = 24.0;
  static const doubleExtraLarge = 26.0;
}

ThemeData lightMode = ThemeData(
  brightness: Brightness.light,
  appBarTheme: const AppBarTheme(
    shadowColor: Colors.white,
  ),
  colorScheme: const ColorScheme.light(
      background: Color.fromARGB(255, 255, 255, 255),
      primary: Color.fromARGB(255, 114, 71, 170),
      secondary: Color.fromARGB(255, 103, 76, 224)),
  inputDecorationTheme: const InputDecorationTheme(
      labelStyle: TextStyle(color: Color.fromARGB(255, 55, 6, 134))),
  textTheme: const TextTheme(
      titleLarge: TextStyle(
        color: Color.fromARGB(255, 0, 0, 0),
      ),
      titleSmall: TextStyle(
        color: Color.fromARGB(122, 0, 0, 0),
      ),
      bodyMedium:
          TextStyle(color: Color(0xffEEEEEE), fontSize: FontSizes.small),
      bodySmall: TextStyle(
          color: Color.fromARGB(255, 255, 255, 255),
          fontSize: FontSizes.small)),
);

ThemeData darkMode = ThemeData(
  brightness: Brightness.dark,
  appBarTheme: const AppBarTheme(
    shadowColor: Color(0xff625b5b),
  ),
  colorScheme: const ColorScheme.dark(
      background: Color.fromARGB(248, 0, 0, 0),
      primary: Color.fromARGB(255, 41, 2, 92),
      secondary: Color.fromARGB(255, 151, 95, 214)),
  textTheme: const TextTheme(
      titleLarge: TextStyle(
        color: Color(0xffEEEEEE),
      ),
      titleSmall: TextStyle(
        color: Color(0xffEEEEEE),
      ),
      bodyMedium:
          TextStyle(color: Color(0xffEEEEEE), fontSize: FontSizes.small),
      bodySmall: TextStyle(
          color: Color.fromARGB(255, 0, 0, 0), fontSize: FontSizes.small)),
);
