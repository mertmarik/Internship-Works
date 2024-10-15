import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class QuestionsSummary extends StatelessWidget {
  QuestionsSummary(this.summaryData, {super.key});
  final List<Map<String, Object>> summaryData;
  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 300,
      child: SingleChildScrollView(
        child: Column(
          children: summaryData.map((data) {
            return Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Padding(
                  padding: const EdgeInsets.all(20.0),
                  child: SizedBox(
                    width: 30.0,
                    height: 30.0,
                    child: DecoratedBox(
                      decoration: const ShapeDecoration(
                        shape: CircleBorder(),
                        color: Color.fromARGB(255, 83, 255, 232),
                      ),
                      child: Center(
                        child: Text(
                          ((data['question_index'] as int) + 1).toString(),
                          style: GoogleFonts.poppins(
                            color: const Color.fromARGB(255, 0, 0, 0),
                            fontSize: 16,
                          ),
                        ),
                      ),
                    ),
                  ),
                ),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(data['question'] as String,
                          style: GoogleFonts.poppins(
                              color: const Color.fromARGB(255, 255, 255, 255),
                              fontSize: 16)),
                      const SizedBox(
                        height: 5,
                      ),
                      Text(data['user_answer'] as String,
                          style: GoogleFonts.poppins(
                              color: const Color.fromARGB(255, 238, 160, 221),
                              fontSize: 16,
                              fontWeight: FontWeight.bold)),
                      Text(data['correct_answer'] as String,
                          style: GoogleFonts.poppins(
                              color: const Color.fromARGB(255, 118, 233, 241),
                              fontSize: 16,
                              fontWeight: FontWeight.bold))
                    ],
                  ),
                ),
              ],
            );
          }).toList(),
        ),
      ),
    );
  }
}
