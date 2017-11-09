namespace GraphBackground
{
  public static class StatisticsAndParams
  {
    public static double DeltaP = 0.05;
    public static double DeltaStep = 0.05;
    public static int Attemps = 0;

    public static void Reset()
    {
      DeltaP=0.05;
      DeltaStep = 0.05;
      Attemps = 0;
    }

    public static void IncreaseDeltaP() => DeltaP += DeltaStep;
  }
}