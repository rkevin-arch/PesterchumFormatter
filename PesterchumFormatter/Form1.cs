using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace PesterchumFormatter
{
    public partial class PesterchumFormatter : Form
    {
        public static PesterchumFormatter instance;
        Font commandFont=null;
        public PesterchumFormatter()
        {
            InitializeComponent();
            //commandFont = new Font("Microsoft Yahei", 12f, FontStyle.Underline);
            commandFont = new Font(output.Font, FontStyle.Underline);
            instance = this;
            input_TextChanged(null, null);
        }
        public void appendOutput(string text)
        {
            appendOutput(text, Color.Black, null);
        }
        public void appendOutput(string text, Color color)
        {
            appendOutput(text, color, null);
        }
        public void appendOutput(string text, Color color, Font font)
        {
            int start = output.TextLength;
            output.AppendText(text);
            output.Select(start, text.Length);
            if (coloringEnabled.Checked)
                output.SelectionColor = color;
            if (fontEnabled.Checked && font != null)
                output.SelectionFont = font;
        }
        public bool quirkEnabled() => quirksEnabled.Checked;
        private void input_TextChanged(object sender, EventArgs e)
        {
            output.Clear();
            foreach (string line in input.Lines)
                processLine(line);
        }
        private void processLine(string line)
        {
            //left in as a joke.
            //line = line.Replace("food", "potato").Replace("vegetables","potatoes").Replace("meat","potatoes").Replace("sandwich","potato");
            if (line.StartsWith("PESTER") || line.StartsWith("TROLL"))
            {
                List<string> args = new List<string>(from str in line.Split(' ') where str != "" select str);
                if (args.Count != 4) { appendOutput("FORMAT ERROR NEED 3 ARGUMENTS\n", Color.Red); return; }
                Chum chum1 = PesterchumAccMgr.findChum(args[1]);
                Chum chum2 = PesterchumAccMgr.findChum(args[2]);
                if (chum1 == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[1]+"\n", Color.Red); return; }
                if (chum2 == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[2]+"\n", Color.Red); return; }
                appendOutput("-- ");
                chum1.printWholeName();
                appendOutput("began " + args[0].ToLower() + "ing ");
                chum2.printWholeName();
                appendOutput("at " + args[3] + " --\n");
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
                appendOutput("-- ");
                chum1.printWholeName();
                appendOutput("ceased " + args[0].Substring(3).ToLower() + "ing ");
                chum2.printWholeName();
                appendOutput("--\n");
                return;
            }
            if(line.StartsWith("IDLE"))
            {
                List<string> args = new List<string>(from str in line.Split(' ') where str != "" select str);
                if (args.Count != 2) { appendOutput("FORMAT ERROR NEED 1 ARGUMENT\n", Color.Red); return; }
                Chum chum = PesterchumAccMgr.findChum(args[1]);
                if (chum == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[1] + "\n", Color.Red); return; }
                appendOutput("-- ");
                chum.printWholeName();
                appendOutput("is now an idle "+(line.StartsWith("IDLETROLL")?"troll":"chum")+"! --\n");
                return;
            }
            if (line.StartsWith("MEMO"))
            {
                List<string> args = new List<string>(from str in line.Split(' ') where str != "" select str);
                if (args.Count < 3) { appendOutput("FORMAT ERROR NEED 4 ARGUMENTS\n", Color.Red); return; }
                args[2] = line.Substring(line.IndexOf(' ', line.IndexOf(' ') + 1) + 1);
                if(args[2].IndexOf(';')==-1) { appendOutput("ARGUMENT 3 and 4 NEED ; IN THE MIDDLE\n", Color.Red); return; }
                Chum chum = PesterchumAccMgr.findChum(args[1]);
                if (chum == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[1] + "\n", Color.Red); return; }
                chum.printWholeName();
                appendOutput(args[2].Substring(0, args[2].IndexOf(';')));
                appendOutput(" opened memo on board ");
                appendOutput(args[2].Substring(args[2].IndexOf(';')+1));
                appendOutput(".\n");
                return;
            }
            if (line.StartsWith("RESPOND"))
            {
                List<string> args = new List<string>(from str in line.Split(' ') where str != "" select str);
                if (args.Count < 3) { appendOutput("FORMAT ERROR NEED 2 ARGUMENTS\n", Color.Red); return; }
                Chum chum = PesterchumAccMgr.findChum(args[1]);
                if (chum == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[1] + "\n", Color.Red); return; }
                chum.printWholeName();
                appendOutput(line.Substring(line.IndexOf(' ', line.IndexOf(' ') + 1)+1) + " responded to memo.\n");
                return;
            }
            if (line.StartsWith("BAN")||line.StartsWith("UNBAN"))
            {
                List<string> args = new List<string>(from str in line.Split(' ') where str != "" select str);
                if (args.Count != 3) { appendOutput("FORMAT ERROR NEED 2 ARGUMENTS\n", Color.Red); return; }
                Chum chum1 = PesterchumAccMgr.findChum(args[1]);
                Chum chum2 = PesterchumAccMgr.findChum(args[2]);
                if (chum1 == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[1] + "\n", Color.Red); return; }
                if (chum2 == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[2] + "\n", Color.Red); return; }
                chum1.printShortName();
                appendOutput(" "+args[0].ToLower()+"ned ");
                chum2.printShortName();
                appendOutput(" from replying to memo.\n");
                return;
            }
            if (line.StartsWith("ENDRESPOND"))
            {
                List<string> args = new List<string>(from str in line.Split(' ') where str != "" select str);
                if (args.Count !=2) { appendOutput("FORMAT ERROR NEED 1 ARGUMENT\n", Color.Red); return; }
                Chum chum = PesterchumAccMgr.findChum(args[1]);
                if (chum == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[1] + "\n", Color.Red); return; }
                chum.printShortName();
                appendOutput(" ceased responding to memo.\n");
                return;
            }
            if (line.StartsWith("ENDMEMO"))
            {
                List<string> args = new List<string>(from str in line.Split(' ') where str != "" select str);
                if (args.Count != 2) { appendOutput("FORMAT ERROR NEED 1 ARGUMENT\n", Color.Red); return; }
                Chum chum = PesterchumAccMgr.findChum(args[1]);
                if (chum == null) { appendOutput("CHUM NOT FOUND ERROR:" + args[1] + "\n", Color.Red); return; }
                chum.printShortName();
                appendOutput(" closed memo.\n");
                return;
            }
            if (line.IndexOf(':') != -1) {
                Chum c = PesterchumAccMgr.findChum(line.Substring(0, line.IndexOf(':')));
                if (c != null)
                {
                    c.Say(line);
                    return;
                }
            }
            if (line.StartsWith("="))
            {
                int arrowLoc = line.IndexOf(">");
                if (arrowLoc != -1)
                {
                    if(!(from c in line.Substring(0, arrowLoc) where c != '=' select c).Any())
                        appendOutput(line + "\n", Color.Blue, commandFont);
                } 
            }
            //left in as a joke.
            //if (line == "potato") appendOutput("PS: FUCK NO.", PesterchumAccMgr.findChum("PS").color);else
            appendOutput(line+"\n");
        }

        private void changeOutputFont_Click(object sender, EventArgs e)
        {
            fontPicker.Font = output.Font;
            if (fontPicker.ShowDialog() == DialogResult.OK)
                output.Font = fontPicker.Font;
            input_TextChanged(null,null);
        }

        private void changeOutputCommandFont_Click(object sender, EventArgs e)
        {
            fontPicker.Font = commandFont;
            if (fontPicker.ShowDialog() == DialogResult.OK)
                commandFont = fontPicker.Font;
            input_TextChanged(null,null);
        }

        private void exportChumList_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd=new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream fs=sfd.OpenFile();
                
            }
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
            list.Add(new Chum("ectoBiologist", 0x0715CD));
            list.Add(new Chum("ghostlyTrickster", 0x0715CD));
            list.Add(new Chum("tentacleTherapist", 0xB536DA));
            list.Add(new Chum("turntechGodhead", 0xE00707));
            list.Add(new Chum("gardenGnostic", 0x4AC925));
            list.Add(new Chum("gutsyGumshoe", 0x00D5F2));
            list.Add(new Chum("tipsyGnostalgic", 0xFF6FF2));
            list.Add(new Chum("timaeusTestified", 0xF2A400));
            list.Add(new Chum("golgothasTerror", 0x1F9400));
            list.Add(new Chum("apocalypseArisen", 0xA10000));
            list.Add(new Chum("adiosToreador", 0xA15000));
            list.Add(new Chum("twinArmageddons", 0xA1A100));
            list.Add(new Chum("carcinoGeneticist", 0x626262));
            list.Add(new Chum("arsenicCatnip", 0x416600));
            list.Add(new Chum("grimAuxiliatrix", 0x008141));
            list.Add(new Chum("gallowsCalibrator", 0x008282));
            list.Add(new Chum("arachnidsGrip", 0x005682));
            //list.Add(new Chum ("centaursTesticle", 0x000056)); //CONFLICT
            list.Add(new Chum("terminallyCapricious", 0x2B0057));
            list.Add(new Chum("caligulasAquarium", 0x6A006A));
            //list.Add(new Chum ("cuttlefishCuller", 0x77003C)); //CONFLICT

            list.Add(new Chum("midnightOrchest", 0x01CB90, line => line.Replace("i", "\n").Replace("I", "i").Replace("\n", "I")));
            list.Add(new Chum("cursedTiphareth", 0x1F4E79));
            list.Add(new Chum("rehistoricEntomologist", 0xAD04BC, line => line.Replace("i", "!").Replace("I", "!")));
            list.Add(new Chum("peripheralSanity", 0x2B2793));
            list.Add(new Chum("endlessPopcorn", 0xFF8976));
            list.Add(new Chum("eyelessSpecter", 0x700966));
            list.Add(new Chum("fatalMastiff", 0x4A9C8C));
            list.Add(new Chum("crystallineCalibrator", 0x607D8B));
            list.Add(new Chum("arcticSoda", 0x93BDCF));
            list.Add(new Chum("decayQuartzglass", 0x556B2F));
            list.Add(new Chum("frozenSalmon", 0x89E3AD));
            list.Add(new Chum("streakyMuscle", 0xAA9922));
            list.Add(new Chum("moldBorne", 0xC00000, line =>
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in line.Replace("o", "oo").Replace("O", "OO"))
                {
                    sb.Append(c);
                    if (c.ToString().ToPinYin().Contains("O"))
                        sb.Append('o');
                }
                return sb.ToString();
            }));
            list.Add(new Chum("determineDemand", 0x70AD47, line =>
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in line.Replace("5", "⭐").Replace("五", "⭐"))
                {
                    sb.Append(c);
                    if (c.ToString().ToPinYin().Contains("S"))
                        sb.Append("⭐");
                }
                return sb.ToString();
            }));
            list.Add(new Chum("randomFractal", 0x0093AF));
            list.Add(new Chum("tulpaSophist", 0x000000));
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
            if (identifier.Length == 3 || (identifier.Length==4 && char.IsDigit(identifier[3]))) //memo user with time shenanigans
            {
                Chum retval = _findChum(identifier.Substring(1, 2));
                if (retval == null) return null;
                retval = retval.getClone();
                switch (identifier[0])
                {
                    case 'F':
                    case 'f':
                        retval.memoState = Chum.MemoState.FUTURE;
                        break;
                    case 'C':
                    case 'c':
                        retval.memoState = Chum.MemoState.CURRENT;
                        break;
                    case 'P':
                    case 'p':
                        retval.memoState = Chum.MemoState.PAST;
                        break;
                    default:
                        retval.memoState = Chum.MemoState.UNKNOWN;
                        break;
                }
                if (identifier.Length == 4) retval.memoUserCnt = int.Parse(identifier.Substring(3));
                return retval;
            }
            if (identifier.Length == 2) //short name is given
            {
                identifier = identifier.ToUpper();
                foreach (Chum c in list)
                    if (c.shortName == identifier) return c;
                return null;
            }
            string tryShortName = Chum.generateShortName(identifier);
            if(tryShortName!="??") //good long name is given
            {
                foreach (Chum c in list)
                    if (c.shortName == tryShortName) return c;
                return null;
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
        public enum MemoState { NONE, FUTURE, CURRENT, PAST, UNKNOWN};
        public string longName, shortName;
        public MemoState memoState = MemoState.NONE;
        public int memoUserCnt = 0;
        public Color color;
        public Font font;
        public delegate string QuirkProcessor(string line);
        public QuirkProcessor addQuirk = null;
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
        public Chum(string longname,int colorHex)
        {
            longName = longname;
            color = Color.FromArgb(colorHex);
            generateShortName();
        }
        public Chum(string longname, string shortname, int colorHex)
        {
            longName = longname;
            color = Color.FromArgb(colorHex);
            shortName=shortname;
        }
        public Chum(string longname,int colorHex,QuirkProcessor quirk)
        {
            longName = longname;
            color = Color.FromArgb(colorHex);
            addQuirk = quirk;
            generateShortName();
        }
        public Chum getClone()
        {
            return (Chum)this.MemberwiseClone();
        }

        public void Say(string line)
        {
            PesterchumFormatter window = PesterchumFormatter.instance;
            if (addQuirk != null&& window.quirkEnabled()) line = line.Substring(0, line.IndexOf(':') + 1) + addQuirk(line.Substring(line.IndexOf(':') + 1));
            window.appendOutput(line + "\n", color, font);
        }
        public void printWholeName()
        {
            PesterchumFormatter window = PesterchumFormatter.instance;
            if (memoState != MemoState.NONE && memoState != MemoState.UNKNOWN)
                window.appendOutput(memoState.ToString() + " ");
            window.appendOutput(longName + " ");
            if (memoUserCnt != 0)
                window.appendOutput(memoUserCnt.ToString() + " ");
            window.appendOutput("[");

            printShortName();

            window.appendOutput("] ");
        }
        public void printShortName()
        {
            PesterchumFormatter window = PesterchumFormatter.instance;
            if (memoState != Chum.MemoState.NONE && memoState != MemoState.UNKNOWN)
                window.appendOutput(memoState.ToString().Substring(0, 1), color, font);
            else if (memoState == MemoState.UNKNOWN)
                window.appendOutput("?", color, font);
            window.appendOutput(shortName, color, font);
            if (memoUserCnt != 0)
                window.appendOutput(memoUserCnt.ToString(), color, font);
        }
    }
}
