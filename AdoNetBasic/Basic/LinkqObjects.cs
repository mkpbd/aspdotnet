namespace AdoNetBasic.Basic
{
    public class LinkqObjects
    {

        public void LinqColors()
        {
            string[] colors = { "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet" };

            var colorQuery = from color in colors where color.Length <= 5 orderby color select color;
        }
    }
}
