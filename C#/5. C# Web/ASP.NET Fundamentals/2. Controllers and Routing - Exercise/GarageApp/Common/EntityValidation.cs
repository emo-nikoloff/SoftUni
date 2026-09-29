namespace GarageApp.Common;

public static class EntityValidation
{
    // Car
    public const int CarMakeMinLength = 1;
    public const int CarMakeMaxLength = 70;

    public const int CarModelMinLength = 1;
    public const int CarModelMaxLength = 100;

    public const int CarProductionMonthMinValue = 1;
    public const int CarProductionMonthMaxValue = 12;

    public const int CarYearMinValue = 1850;

    // Garage
    public const int GarageNameMinValue = 3;
    public const int GarageNameMaxValue = 75;

    public const int GarageLocationMinLength = 4;
    public const int GarageLocationMaxLength = 120;
}
