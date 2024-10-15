import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:http_parser/http_parser.dart';

class GeminiApi {
  final String apiKey;
  static const String baseUrl = 'https://api.generativeai.google/v1';

  GeminiApi(this.apiKey);

  Future<Map<String, dynamic>> uploadFile(
      String filePath, String mimeType) async {
    try {
      final url = Uri.parse('$baseUrl/upload');
      final file = await http.MultipartFile.fromPath('file', filePath,
          contentType: MediaType('application', 'vnd.google-apps.spreadsheet'));

      final request = http.MultipartRequest('POST', url)
        ..files.add(file)
        ..fields['mime_type'] = mimeType;

      final response = await request.send();

      if (response.statusCode == 200) {
        final responseBody = await response.stream.bytesToString();
        return json.decode(responseBody);
      } else {
        throw Exception('Failed to upload file: ${response.reasonPhrase}');
      }
    } catch (e) {
      throw Exception('Failed to upload file: $e');
    }
  }

  Future<void> waitForFileProcessing(String fileId) async {
    try {
      final url = Uri.parse('$baseUrl/files/$fileId');

      while (true) {
        final response =
            await http.get(url, headers: {'Authorization': 'Bearer $apiKey'});

        if (response.statusCode == 200) {
          final fileStatus = json.decode(response.body);

          if (fileStatus['state'] == 'ACTIVE') {
            break;
          } else if (fileStatus['state'] == 'FAILED') {
            throw Exception('File processing failed');
          } else {
            await Future.delayed(const Duration(seconds: 10));
          }
        } else {
          throw Exception(
              'Failed to check file status: ${response.reasonPhrase}');
        }
      }
    } catch (e) {
      throw Exception('Error waiting for file processing: $e');
    }
  }

  Future<Map<String, dynamic>> startChatSession(
      List<Map<String, dynamic>> history) async {
    try {
      final url = Uri.parse('$baseUrl/chat_sessions');
      final headers = {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer $apiKey',
      };
      final body = json.encode({
        'model': 'gemini-1.5-flash', // Adjust model name as necessary
        'history': history,
      });

      final response = await http.post(url, headers: headers, body: body);

      if (response.statusCode == 200) {
        return json.decode(response.body);
      } else {
        throw Exception(
            'Failed to start chat session: ${response.reasonPhrase}');
      }
    } catch (e) {
      throw Exception('Error starting chat session: $e');
    }
  }

  Future<Map<String, dynamic>> sendMessage(
      String sessionId, String message) async {
    try {
      final url = Uri.parse('$baseUrl/chat_sessions/$sessionId/messages');
      final headers = {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer $apiKey',
      };
      final body = json.encode({
        'role': 'user',
        'parts': [message],
      });

      final response = await http.post(url, headers: headers, body: body);

      if (response.statusCode == 200) {
        return json.decode(response.body);
      } else {
        throw Exception('Failed to send message: ${response.reasonPhrase}');
      }
    } catch (e) {
      throw Exception('Error sending message: $e');
    }
  }
}
