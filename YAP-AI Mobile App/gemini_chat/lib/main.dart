import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:gemini_gpt/signin/onboarding.dart';
import 'package:gemini_gpt/theme_notifier.dart';
import 'package:gemini_gpt/themes.dart';
import 'package:hive_flutter/hive_flutter.dart';
import 'package:gemini_gpt/message_adapter.dart';

void main() async {
  await Hive.initFlutter();
  await Hive.openBox<MessageAdp>('messages');
  runApp(const ProviderScope(child: MyApp()));
}

class MyApp extends ConsumerWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final themeMode = ref.watch(themeProvider);

    return MaterialApp(
      title: 'Flutter Demo',
      theme: lightMode,
      darkTheme: darkMode,
      themeMode: themeMode,
      home:  Onboarding(),
      debugShowCheckedModeBanner: false,
    );
  }
}
