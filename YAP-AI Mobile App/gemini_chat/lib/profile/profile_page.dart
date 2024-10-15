import 'package:flutter/material.dart';
import 'package:gemini_gpt/my_home_page.dart';
import 'package:gemini_gpt/profile/profile_menu.dart';
import 'package:gemini_gpt/theme_notifier.dart';
import 'package:gemini_gpt/profile/update_profile_screen.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class ProfilePage extends ConsumerStatefulWidget {
  const ProfilePage({super.key});

  @override
  ConsumerState<ProfilePage> createState() {
    return _ProfilePageState();
  }
}

class _ProfilePageState extends ConsumerState<ProfilePage> {
  @override
  Widget build(BuildContext context) {
    final currentTheme = ref.watch(themeProvider);
    return Scaffold(
      backgroundColor: (currentTheme == ThemeMode.light)
          ? Theme.of(context).colorScheme.background
          : Theme.of(context).colorScheme.background,
      appBar: AppBar(
        leading: IconButton(
          onPressed: () {
            Navigator.pushAndRemoveUntil(
                context,
                MaterialPageRoute(builder: (context) => const MyHomePage()),
                (route) => false);
          },
          icon: const Icon(Icons.chevron_left_rounded),
        ),
        title: Text(
          "Profile",
          style: TextStyle(
            color:
                (currentTheme == ThemeMode.light) ? Colors.black : Colors.white,
          ),
        ),
        actions: [
          IconButton(
              onPressed: () {
                ref.read(themeProvider.notifier).toggleTheme();
              },
              icon: Icon(currentTheme == ThemeMode.light
                  ? Icons.light_mode
                  : Icons.dark_mode_sharp)),
        ],
      ),
      body: SingleChildScrollView(
          child: Container(
        padding: const EdgeInsets.all(20),
        child: Column(
          children: [
            Stack(
              children: [
                SizedBox(
                  width: 120,
                  height: 120,
                  child: ClipRRect(
                    borderRadius: BorderRadius.circular(100),
                    child: const Image(
                      image: AssetImage("assets/profilepic.jpg"),
                    ),
                  ),
                ),
                Positioned(
                  bottom: 0,
                  right: 0,
                  child: Container(
                    width: 30,
                    height: 30,
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(100),
                      color: (currentTheme == ThemeMode.light)
                          ? Colors.black
                          : Colors.white,
                    ),
                    child: Icon(
                      Icons.create,
                      color: (currentTheme == ThemeMode.light)
                          ? Colors.white
                          : Colors.black,
                      size: 20.0,
                    ),
                  ),
                ),
              ],
            ),
            const SizedBox(
              height: 10,
            ),
            Text(
              "Mert Arık",
              style: Theme.of(context).textTheme.titleLarge,
            ),
            Text(
              "mertyazilim13@gmail.com",
              style: TextStyle(
                color: (currentTheme == ThemeMode.light)
                    ? Color.fromARGB(167, 0, 0, 0)
                    : const Color.fromARGB(117, 255, 255, 255),
              ),
            ),
            const SizedBox(
              height: 20,
            ),
            SizedBox(
              width: 200,
              child: ElevatedButton(
                onPressed: () {
                  Navigator.pushAndRemoveUntil(
                      context,
                      MaterialPageRoute(
                          builder: (context) => const UpdateProfileScreen()),
                      (route) => false);
                },
                style: (currentTheme == ThemeMode.light)
                    ? ElevatedButton.styleFrom(
                        backgroundColor: const Color.fromARGB(255, 0, 0, 0),
                        side: BorderSide.none,
                        shape: const StadiumBorder())
                    : ElevatedButton.styleFrom(
                        backgroundColor: Color.fromARGB(139, 255, 255, 255),
                        side: BorderSide.none,
                        shape: const StadiumBorder()),
                child: Text(
                  "Edit Profile",
                  style: TextStyle(
                      fontWeight: FontWeight.bold,
                      color: (currentTheme == ThemeMode.light)
                          ? Colors.white
                          : Colors.black),
                ),
              ),
            ),
            const SizedBox(
              height: 30,
            ),
            const Divider(),
            const SizedBox(
              height: 10,
            ),
            ProfileMenuWidget(
              title: "Settings",
              icon: Icons.settings,
              onPress: () {},
            ),
            ProfileMenuWidget(
              title: "Billing",
              icon: Icons.money_outlined,
              onPress: () {},
            ),
            ProfileMenuWidget(
              title: "User Management",
              icon: Icons.person,
              onPress: () {},
            ),
            const Divider(),
            const SizedBox(
              height: 10,
            ),
            ProfileMenuWidget(
              title: "Information",
              icon: Icons.info,
              onPress: () {},
            ),
            ProfileMenuWidget(
              title: "Logout",
              icon: Icons.logout,
              textColor: Colors.red,
              endIcon: false,
              onPress: () {},
            ),
          ],
        ),
      )),
    );
  }
}
