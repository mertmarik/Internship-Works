// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'message_adapter.dart';

// **************************************************************************
// TypeAdapterGenerator
// **************************************************************************

class MessageAdapter extends TypeAdapter<MessageAdp> {
  @override
  final int typeId = 0;

  @override
  MessageAdp read(BinaryReader reader) {
    final numOfFields = reader.readByte();
    final fields = <int, dynamic>{
      for (int i = 0; i < numOfFields; i++) reader.readByte(): reader.read(),
    };
    return MessageAdp(
      text: fields[0] as String,
      isUser: fields[1] as bool,
    );
  }

  @override
  void write(BinaryWriter writer, MessageAdp obj) {
    writer
      ..writeByte(2)
      ..writeByte(0)
      ..write(obj.text)
      ..writeByte(1)
      ..write(obj.isUser);
  }

  @override
  int get hashCode => typeId.hashCode;

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is MessageAdapter &&
          runtimeType == other.runtimeType &&
          typeId == other.typeId;
}
