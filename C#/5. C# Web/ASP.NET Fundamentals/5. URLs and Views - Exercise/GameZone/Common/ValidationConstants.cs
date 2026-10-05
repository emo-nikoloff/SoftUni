namespace GameZone.Common
{
    public static class ValidationConstants
    {
        public static class Genre
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 70;
        }

        public static class Game
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 120;

            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 1000;

            public const int ImageUrlMaxLength = 2083;

            public const int PublisherMinLength = 3;
            public const int PublisherMaxLength = 100;
        }
    }
}
