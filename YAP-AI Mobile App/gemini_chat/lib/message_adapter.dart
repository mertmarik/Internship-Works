import 'package:hive/hive.dart';

part 'message_adapter.g.dart';

@HiveType(typeId: 0)
class MessageAdp {
  @HiveField(0)
  final String text;

  @HiveField(1)
  final bool isUser;

  MessageAdp({required this.text, required this.isUser});
}