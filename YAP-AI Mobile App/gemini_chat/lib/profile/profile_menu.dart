import 'package:flutter/material.dart';
import 'package:gemini_gpt/theme_notifier.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class ProfileMenuWidget extends ConsumerStatefulWidget {
  const ProfileMenuWidget({
    Key? key,
    required this.title,
    required this.icon,
    required this.onPress,
    this.textColor = Colors.black,
    this.endIcon = true,
  }) : super(key: key);

  final String title;
  final IconData icon;
  final VoidCallback onPress;
  final bool endIcon;
  final Color? textColor;

  @override
  ConsumerState<ProfileMenuWidget> createState() => _ProfileMenuWidgetState();
}

class _ProfileMenuWidgetState extends ConsumerState<ProfileMenuWidget> {
  @override
  Widget build(BuildContext context) {
    final currentTheme = ref.watch(
        themeProvider); // Use ref here if you have access to ref in this scope

    return ListTile(
      onTap: widget.onPress,
      leading: Container(
        width: 30,
        height: 30,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(100),
          color: (currentTheme == ThemeMode.light)
              ? const Color.fromARGB(255, 255, 255, 255).withOpacity(0.1)
              : Colors.black,
        ),
        child: Icon(
          widget.icon,
          color:
              (currentTheme == ThemeMode.light) ? Colors.black : Colors.white,
        ),
      ),
      title: Text(
        widget.title,
        style: TextStyle(
          color:
              (currentTheme == ThemeMode.light) ? Colors.black : Colors.white,
        ),
      ),
      trailing: widget.endIcon
          ? Container(
              width: 30,
              height: 30,
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(100),
                color: Colors.grey.withOpacity(0.1),
              ),
              child: const Icon(
                Icons.chevron_right_sharp,
                color: Colors.grey,
                size: 18.0,
              ),
            )
          : null,
    );
  }
}
