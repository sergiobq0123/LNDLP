public class Filter {

    public class ContentType {
        public const string PlainText = "plainText";
        public const string EditableTextFields = "editableTextFields";
        public const string DropdownFields = "dropdownFields";
        public const string RadioButtons = "radioButtons";
        public const string Checkbox = "checkbox";
        public const string DatePicker = "datePicker";
        public const string SpecialContent = "specialContent";
    }

    public class ConditionType {
        public const string Is = "is";
        public const string IsNot = "is not";
        public const string Contains = "contains";
        public const string MoreOrEquals = "more or equals";
        public const string LessOrEquals = "less or equals";
        public const string Between = "between";
        public const string Today = "today";
        public const string Yesterday = "yesterday";
        public const string ThisWeek = "this week";
        public const string LastWeek = "last week";
        public const string ThisMonth = "this month";
        public const string LastMonth = "last month";
        public const string ThisYear = "this year";
        public const string LastYear = "last year";
    }

    public string DataKey {get; set;}
    public string Type {get; set;}
    public string Condition {get; set;}
    public string? FilterInput {get; set;}
    public DateTime? StartDate {get; set;}
    public DateTime? EndDate {get; set;}
}