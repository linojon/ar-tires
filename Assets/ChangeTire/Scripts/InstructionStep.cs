using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionStep {
    public string Name;
    public string Title;
    public string BodyText;

    private const int NameColumn = 0;
    private const int TitleColumn = 1;
    private const int BodyColumn = 2;

    public InstructionStep(List<string> values) {
        foreach (string item in values) {
            if (values.IndexOf(item) == NameColumn) {
                Name = item;
            }
            if (values.IndexOf(item) == TitleColumn) {
                Title = item;
            }
            if (values.IndexOf(item) == BodyColumn) {
                BodyText = item;
            }
        }
    }
}
