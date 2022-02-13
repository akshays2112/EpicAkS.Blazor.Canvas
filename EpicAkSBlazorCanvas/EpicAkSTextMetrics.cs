using System.Text.Json.Serialization;
using EpicAkSBlazorCanvas.Structs;

namespace EpicAkSBlazorCanvas
{
    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics</summary>
    public class EpicAkSTextMetrics : EpicAkSReturnVar
    {
        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics/width</summary>
        [JsonPropertyName("width")]
        public double Width { get; init; }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics/actualBoundingBoxLeft</summary>
        [JsonPropertyName("actualBoundingBoxLeft")]
        public double ActualBoundingBoxLeft { get; init; }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics/actualBoundingBoxRight</summary>
        [JsonPropertyName("actualBoundingBoxRight")]
        public double ActualBoundingBoxRight { get; init; }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics/fontBoundingBoxAscent</summary>
        [JsonPropertyName("fontBoundingBoxAscent")]
        public double FontBoundingBoxAscent { get; init; }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics/fontBoundingBoxDescent</summary>
        [JsonPropertyName("fontBoundingBoxDescent")]
        public double FontBoundingBoxDescent { get; init; }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics/actualBoundingBoxAscent</summary>
        [JsonPropertyName("actualBoundingBoxAscent")]
        public double ActualBoundingBoxAscent { get; init; }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics/actualBoundingBoxDescent</summary>
        [JsonPropertyName("actualBoundingBoxDescent")]
        public double ActualBoundingBoxDescent { get; init; }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics/emHeightAscent</summary>
        [JsonPropertyName("emHeightAscent")]
        public double EmHeightAscent { get; init; }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics/emHeightDescent</summary>
        [JsonPropertyName("emHeightDescent")]
        public double EmHeightDescent { get; init; }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics/hangingBaseline</summary>
        [JsonPropertyName("hangingBaseline")]
        public double HangingBaseline { get; init; }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics/alphabeticBaseline</summary>
        [JsonPropertyName("alphabeticBaseline")]
        public double AlphabeticBaseline { get; init; }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics/ideographicBaseline</summary>
        [JsonPropertyName("ideographicBaseline")]
        public double IdeographicBaseline { get; init; }

        ///<summary></summary>
        public EpicAkSTextMetrics()
        {
            base.PropertyNames = EpicAkSBlazorCanvasHelpers.FillPropertyNames(this.GetType());
        }
    }
}
