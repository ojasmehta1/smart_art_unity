using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class UpdatePanel : MonoBehaviour
{
    [SerializeField]
    private Text titleText;

    [SerializeField]
    private Text descriptionText;

    [SerializeField]
    private GameObject welcomePanel;

    [SerializeField]
    private Button dismissButton;

    [SerializeField]
    private RawImage rawImage;

    Texture2D tex;
    [SerializeField]
    private TextAsset monalisaByte;
    [SerializeField]
    private TextAsset cafeterraceByte;
    [SerializeField]
    private TextAsset irisesByte;
    [SerializeField]
    private TextAsset nightcafeByte;
    [SerializeField]
    private TextAsset rainstormByte;

    [SerializeField]
    private TextAsset starrynightByte;
    [SerializeField]
    private TextAsset thegreatwaveByte;

    
    private ARTrackedImageManager m_TrackedImageManager;


    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        dismissButton.onClick.AddListener(Dismiss);
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();

       // tex.LoadImage(starrynightByte.bytes);
       // rawImage.texture = tex;

        tex = new Texture2D(2, 2);

    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        welcomePanel.SetActive(false);
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void Dismiss() => welcomePanel.SetActive(false);

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            welcomePanel.SetActive(true);
            setDescription(trackedImage);
            //rawImage = trackedImage;
            // Give the initial image a reasonable default scale
            trackedImage.transform.localScale =
                new Vector3(-trackedImage.referenceImage.size.x, 0.005f, -trackedImage.referenceImage.size.y);
        }


        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
           // welcomePanel.SetActive(true);
            setDescription(trackedImage);
            // Display the name of the tracked image in the canvas
              titleText.text = trackedImage.referenceImage.name;
            // Give the initial image a reasonable default scale
            trackedImage.transform.localScale =
                new Vector3(-trackedImage.referenceImage.size.x, 0.005f, -trackedImage.referenceImage.size.y);
        }
    }

    void setDescription(ARTrackedImage trackedImage)
    {
        string imageTitle = trackedImage.referenceImage.name;
        switch (trackedImage.referenceImage.name)
        {
            case ("Rainstorm"):
                tex.LoadImage(rainstormByte.bytes);
                titleText.text = "Rainstorm Under the Summit";
                descriptionText.text = ("Title: Katsushika Hokusai, 'Rainstorm Beneath the Summit' (Sanka haku'u), a colour woodblock print\n" +
                        "Date Created: 1831/1831\n" +
                        "Physical Dimensions: Height: 24.10cm; Width: 36.50cm\n" +
                        "Technique: woodblock\n" +
                        "Subject: landscape; storm\n" +
                        "Registration number: 1906,1220,0.526\n" +
                        "Production place: Published in Edo\n" +
                        "Producer: Print artist Katsushika Hokusai. Published by Nishimuraya Yohachi\n" +
                        "Period/culture: Edo Period\n" +
                        "Material: paper\n" +
                        "Copyright: Photo: © Trustees of the British Museum\n" +
                        "Acquisition: Purchased from Morrison, Arthur");
                descriptionText.text += ("\n \n \nDESCRIPTION:\n" + "This print is only superficially different in composition toHokusai's 'South Wind, Clear Sky', and yet the two designs are deliberately contrasting, down to the smallest detail. The calm, bright dawn has given way to agitation and darkness, as a sudden storm erupts around the base of the mountain, with jagged lightning forming an untidy echo of the slopes.The manner of drawing Fuji's triple summit with a deep ravine on the left side is interpreted to show the 'back' (that is, north) side of Mt Fuji.");
                break;
            case "Cafe Terrace":
                tex.LoadImage(cafeterraceByte.bytes);
                titleText.text = "Cafe Terrace";
               descriptionText.text = ("Title: Terrace of a café at night(Place du Forum)" +
                                       "Creator: Vincent van Gogh" +
                                       "Date Created: c. 16 September 1888" +
                                       "Original Title: Caféterras bij nacht(Place du Forum");
                descriptionText.text += ("\n\n\nDESCRIPTION:\n" + "Van Gogh had intended to make a nocturnal painting for some time. And not one in the conventional manner, in shades of black and grey, but actually with an abundance of colours.Equally unconventional is that he paints this gas - lit terrace of a café in Arles in situ and in the dark, because colours have a different appearance during the day than by night\"");
                break;
            case ("Mona Lisa"):
                tex.LoadImage(monalisaByte.bytes);
                // rawImage.texture = monalisatexture;
                titleText.text = trackedImage.referenceImage.name;
                descriptionText.text = "Artist: Leonardo da Vinci\n Year:c. 1503–1506, perhaps continuing until c. 1517\n Medium:Oil on poplar panel\n Subject:Lisa Gherardini\n Dimensions: 77 cm × 53 cm (30 in × 21 in)\n Location: The Louvre Museum, Paris\n \n";
                descriptionText.text += "\n\n\nDESCRIPTION:\n The Mona Lisa is a half - length portrait painting by the Italian Renaissance artist Leonardo da Vinci that has been described as \"the best known, the most visited, the most written about, the most sung about, the most parodied work of art in the world.\"";
                break;
            case ("Starry Night"):
                tex.LoadImage(starrynightByte.bytes);
                titleText.text = "Starry Night";
                descriptionText.text = (" Title: The Starry Night\n" +
                        "Creator: Vincent van Gogh\n" +
                        "Date Created: 1889\n" +
                        "Location Created: Saint-Rémy-de-Provence\n" +
                        "Style: Post-Impressionism\n" +
                        "Provenance: Acquired through the Lillie P.Bliss Bequest\n" +
                        "Physical Dimensions: w921 x h737 mm\n" +
                        "Original Title: La nuit étoilée\n" +
                        "Medium: Oil on canvas");
                descriptionText.text += ("\n\n\nDESCRIPTION:\n" + "Van Gogh's night sky is a field of roiling energy. Below the exploding stars, the village is a place of quiet order. Connecting earth and sky is the flamelike cypress, a tree traditionally associated with graveyards and mourning. But death was not ominous for van Gogh. \"Looking at the stars always makes me dream,\" he said, \"Why, I ask myself, shouldn't the shining dots of the sky be as accessible as the black dots on the map of France? Just as we take the train to get to Tarascon or Rouen, we take death to reach a star.\"");
                break;
            case ("The Great Wave"):
                tex.LoadImage(thegreatwaveByte.bytes);
                titleText.text = "The Great Wave";
                descriptionText.text = ("Title: The Great Wave off the Coast of Kanagawa\n" +
                        "Creator: Katsushika Hokusai\n" +
                        "Date Created: 1831\n" +
                        "Physical Dimensions: 10\"h x 14\"w\n" +
                        "Type: work on paper\n" +
                        "Medium: woodblock print\n" +
                        "Culture: Japanese\n" +
                        "Credit Line: Museum Purchase\n" +
                        "Creator Death Date: 1849\n" +
                        "Creator Birth Date: 1760");
                descriptionText.text += ("\n\n\nDESCRIPTION:\n" + "This iconic composition comes from the golden age of Japanese woodblock printmaking. Hokusai manages, through the clever and dramatic manipulation of space, to dwarf Japan's snow-capped Mt. Fuji with the enormous wave, which is about to crash down in the foreground.");
                break;
            case ("The Night Cafe"):
                tex.LoadImage(nightcafeByte.bytes);
                titleText.text = "The Night Cafe";
                descriptionText.text = ("Artist: Vincent van Gogh\n" +
                        "Year 1888\n" +
                        "Medium: Oil on canvas\n" +
                        "Dimensions: 72.4 cm × 92.1 cm (28.5 in × 36.3 in)\n" +
                        "Location: Yale University Art Gallery, New Haven");
                descriptionText.text += ("\n\n\nDESCRIPTION:\n" + "The Night Café is an oil painting created by Dutch artist Vincent van Gogh in September 1888 in Arles.[1] Its title is inscribed lower right beneath the signature. The painting is owned by Yale University and is currently held at the Yale University Art Gallery in New Haven, Connecticut.");
                break;
            case ("Irises"):
                tex.LoadImage(irisesByte.bytes);
                titleText.text = "Irises";
                descriptionText.text = ("Title: Irises\n" +
                        "Creator: Vincent van Gogh\n" +
                        "Date Created: 1889\n" +
                        "Location Created: Saint-Rémy, France\n" +
                        "Physical Dimensions: w93 x h71.1 cm\n" +
                        "Type: Painting\n" +
                        "Medium: Oil on canvas\n" +
                        "artist: Vincent van Gogh (Dutch, 1853 - 1890)\n" +
                        "Subject: Irises, Gardens, Landscapes, Still Lifes");
                descriptionText.text += ("\n\n\nDESCRIPTION:\n" + "In May 1889, after episodes of self-mutilation and hospitalization, Vincent van Gogh chose to enter an asylum in Saint-Rémy, France. There, in the last year before his death, he created almost 130 paintings. Within the first week, he began Irises, working from nature in the asylum's garden. The cropped composition, divided into broad areas of vivid color with monumental irises overflowing its borders, was probably influenced by the decorative patterning of Japanese woodblock prints. There are no known drawings for this painting; Van Gogh himself considered it a study. ");
                break;
        }
        rawImage.texture = tex;
    }

}
