using System.ComponentModel;

namespace Planning.Common
{
    public enum WarningType
    {
        none,
        minimum_level,
        maximum_level
    }
    public enum PlantEnum
    {
        [Description("COVA")]
        COVA = 1,
        [Description("PLANT_TEST")]
        PLANT_TEST = 2
    }

    public enum ContainerEnum
    {
        [Description("V560TA002/003")]
        V560TA002_003 = 1,
        [Description("V560TA002/004")]
        V560TA002_004 = 2
    }

    public enum WasteEnum
    {

        [Description("Acque di strato")]
        LayerWaters = 1,
        [Description("Acque di strato Test")]
        LayerTest = 2
    }
}
