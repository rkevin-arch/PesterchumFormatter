using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PesterchumFormatter
{
    public partial class PesterchumFormatter : Form
    {
        public PesterchumFormatter()
        {
            InitializeComponent();
            input_TextChanged(null, null);
        }
        private void appendOutput(string text)
        {
            appendOutput(text, Color.Black);
        }
        private void appendOutput(string text, Color color)
        {
            int start = output.TextLength;
            output.AppendText(text);
            output.Select(start, text.Length);
            output.SelectionColor = color;
        }
        private void input_TextChanged(object sender, EventArgs e)
        {
            output.Clear();
            foreach (string line in input.Lines)
                processLine(line);
        }
        private void processLine(string line)
        {
            if (line.StartsWith("PESTER") || line.StartsWith("TROLL"))
            {
                List<string> args = new List<string>(from str in line.Split(' ') where str != "" select str);
                if (args.Count != 4) { appendOutput("FORMAT ERROR NEED 3 ARGUMENTS\n", Color.Red); return; }
                Chum chum1 = PesterchumAccMgr.findChum(args[1]);
                Chum chum2 = PesterchumAccMgr.findChum(args[2]);
                if (chum1 == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[1]+"\n", Color.Red); return; }
                if (chum2 == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[2]+"\n", Color.Red); return; }
                appendOutput("-- " + chum1.longName + " [");
                appendOutput(chum1.shortName, chum1.color);
                appendOutput("] began "+args[0].ToLower()+"ing " + chum2.longName + " [");
                appendOutput(chum2.shortName, chum2.color);
                appendOutput("] at " + args[3] + " --\n");
                return;
            }
            if (line.StartsWith("ENDPESTER") || line.StartsWith("ENDTROLL"))
            {
                List<string> args = new List<string>(from str in line.Split(' ') where str != "" select str);
                if (args.Count != 3) { appendOutput("FORMAT ERROR NEED 2 ARGUMENTS\n", Color.Red); return; }
                Chum chum1 = PesterchumAccMgr.findChum(args[1]);
                Chum chum2 = PesterchumAccMgr.findChum(args[2]);
                if (chum1 == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[1] + "\n", Color.Red); return; }
                if (chum2 == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[2] + "\n", Color.Red); return; }
                appendOutput("-- " + chum1.longName + " [");
                appendOutput(chum1.shortName, chum1.color);
                appendOutput("] ceased " + args[0].Substring(3).ToLower() + "ing " + chum2.longName + " [");
                appendOutput(chum2.shortName, chum2.color);
                appendOutput("] --\n");
                return;
            }
            if(line.StartsWith("IDLE"))
            {
                List<string> args = new List<string>(from str in line.Split(' ') where str != "" select str);
                if (args.Count != 2) { appendOutput("FORMAT ERROR NEED 1 ARGUMENT\n", Color.Red); return; }
                Chum chum = PesterchumAccMgr.findChum(args[1]);
                if (chum == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[1] + "\n", Color.Red); return; }
                appendOutput("-- " + chum.longName + " [");
                appendOutput(chum.shortName, chum.color);
                appendOutput("] is now an idle "+(line.StartsWith("IDLETROLL")?"troll":"chum")+"! --\n");
                return;
            }
            if (line.Length>2 && line[2] == ':')
            {
                appendOutput(line + "\n", PesterchumAccMgr.findChum(line.Substring(0, 2)).color);
                return;
            }
            appendOutput(line+"\n");

        }
    }
    //too lazy to create a new file
    class PesterchumAccMgr
    {
        List<Chum> list=new List<Chum>();
        static PesterchumAccMgr instance = null;
        private PesterchumAccMgr()
        {
            //for now, hard code items
            list.Add(new Chum { longName = "ectoBiologist", color = Color.FromArgb(0x000715CD) });
            list.Add(new Chum { longName = "ghostlyTrickster", color = Color.FromArgb(0x000715CD) });
            list.Add(new Chum { longName = "tentacleTherapist", color = Color.FromArgb(0x00B536DA) });
            list.Add(new Chum { longName = "turntechGodhead", color = Color.FromArgb(0x00E00707) });
            list.Add(new Chum { longName = "gardenGnostic", color = Color.FromArgb(0x004AC925) });
            list.Add(new Chum { longName = "gutsyGumshoe", color = Color.FromArgb(0x0000D5F2) });
            list.Add(new Chum { longName = "tipsyGnostalgic", color = Color.FromArgb(0x00FF6FF2) });
            list.Add(new Chum { longName = "timaeusTestified", color = Color.FromArgb(0x00F2A400) });
            list.Add(new Chum { longName = "golgothasTerror", color = Color.FromArgb(0x001F9400) });
            list.Add(new Chum { longName = "apocalypseArisen", color = Color.FromArgb(0x00A10000) });
            list.Add(new Chum { longName = "adiosToreador", color = Color.FromArgb(0x00A15000) });
            list.Add(new Chum { longName = "twinArmageddons", color = Color.FromArgb(0x00A1A100) });
            list.Add(new Chum { longName = "carcinoGeneticist", color = Color.FromArgb(0x00626262) });
            list.Add(new Chum { longName = "arsenicCatnip", color = Color.FromArgb(0x00416600) });
            list.Add(new Chum { longName = "grimAuxiliatrix", color = Color.FromArgb(0x00008141) });
            list.Add(new Chum { longName = "gallowsCalibrator", color = Color.FromArgb(0x00008282) });
            list.Add(new Chum { longName = "arachnidsGrip", color = Color.FromArgb(0x00005682) });
            //list.Add(new Chum { longName = "centaursTesticle", color = Color.FromArgb(0x00000056) }); //CONFLICT
            list.Add(new Chum { longName = "terminallyCapricious", color = Color.FromArgb(0x002B0057) });
            list.Add(new Chum { longName = "caligulasAquarium", color = Color.FromArgb(0x006A006A) });
            //list.Add(new Chum { longName = "cuttlefishCuller", color = Color.FromArgb(0x0077003C) }); //CONFLICT

            list.Add(new Chum { longName = "midnightOrchest", color = Color.FromArgb(0x004BDEDA) });
            list.Add(new Chum { longName = "cursedTiphareth", color = Color.FromArgb(0x001F4E79) });
            list.Add(new Chum { longName = "rehistoricEntomologist", color = Color.FromArgb(0x00AD04BC) });
            list.Add(new Chum { longName = "moldBorne", color = Color.FromArgb(0x00C00000) });
            list.Add(new Chum { longName = "peripheralSanity", color = Color.FromArgb(0x002B2793) });
            list.Add(new Chum { longName = "endlessPopcorn", color = Color.FromArgb(0x00FF8976) });
            list.Add(new Chum { longName = "eyelessSpecter", color = Color.FromArgb(0x007A0966) });
            list.Add(new Chum { longName = "determineDemand", color = Color.FromArgb(0x0070AD47) });
            list.Add(new Chum { longName = "crystallineCalibrator", color = Color.FromArgb(0x00607D8B) });
            list.Add(new Chum { longName = "decayQuartzglass", color = Color.FromArgb(0x00556B2F) });
            list.Add(new Chum { longName = "steakyMuscle", color = Color.FromArgb(0x00FFE228) });
            list.Add(new Chum { longName = "frozenSalmon", color = Color.FromArgb(0x0089E3AD) });
            foreach(Chum c in list)
                if (string.IsNullOrEmpty(c.shortName)) c.generateShortName();

        }
        private static PesterchumAccMgr getInstance()
        {
            if (instance == null)
                instance = new PesterchumAccMgr();
            return instance;
        }
        private Color _longNameToColor(string longname)
        {
            foreach (Chum c in list)
                if (c.longName == longname) return c.color;
            return Color.Black;
        }
        public static Color longNameToColor(string longname)
        {
            return getInstance()._longNameToColor(longname);
        }
        private Chum _findChum(string identifier)
        {
            if(identifier.Length>4 && identifier.EndsWith("]") && identifier[identifier.Length-4]=='[') //specified custom short name
            {
                string shortName = identifier.Substring(identifier.Length - 3, 2);
                foreach (Chum c in list)
                    if (c.shortName == shortName) return c;
                //no chum found, create
                Chum c1 = new Chum { longName = identifier.Substring(0, identifier.Length - 5), shortName = shortName, color = Color.Black };
                list.Add(c1);
                return c1;
            }
            if (identifier.Length == 2) //short name is given
            {
                foreach (Chum c in list)
                    if (c.shortName == identifier) return c;
                //no chum found, create
                Chum c2 = new Chum { longName = "UNKNOWN", shortName = identifier, color = Color.Black };
                list.Add(c2);
                return c2;
            }
            string tryShortName = Chum.generateShortName(identifier);
            if(tryShortName!="??") //good long name is given
            {
                foreach (Chum c in list)
                    if (c.shortName == tryShortName) return c;
                //no chum found, create
                Chum c3 = new Chum { longName = identifier, shortName = tryShortName, color = Color.Black };
                list.Add(c3);
                return c3;
            }
            return null; //flip the fvck out because idk what to do
        }
        public static Chum findChum(string identifier)
        {
            return getInstance()._findChum(identifier);
        }
    }
    class Chum
    {
        public string longName,shortName;
        public Color color;
        public static string generateShortName(string longName)
        {
            if (!char.IsLower(longName[0]))
                return "??";
            List<char> tmp = new List<char>(from c in longName where char.IsUpper(c) select c);
            if (tmp.Count != 1) return "??";
            return "" + char.ToUpper(longName[0]) + tmp[0];
        }
        public void generateShortName()
        {
            shortName = generateShortName(longName);
        }
    }
}
