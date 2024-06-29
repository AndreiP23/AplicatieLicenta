using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Util
{
    public class Constants
    {
        public static readonly string MsgInfoLiceu = @"Acesta este un test pentru profilul {0}. In anul {1} exista {2} de licee cau au acest profil in Bucuresti. Cea mai mare medie din cadrul acestui profil este {3}, iar cea mai mica medie este {4}. In medie, diferenta dintre ultima medie de anul acesta si anul trecut este {5}. Numarul mediu de locuri pentru acest profil in anul selectat este de {6}";
        public static readonly string MsgAdmis = @"Graficul alaturat reprezinta o figura a situatiei mediilor de admitere a candidatilor din anul trecut. Colorat in rosu se poate observa procentul candidatilor cu media mai mica decat cea introdusa in campul alaturat. Colorat in albastru se poate observa completarea cu procentul candiatiilor a caror medie este mai mare decat cea introdusa. Folositi aceasta informatie pentru a intelege pozitia in care va aflati!";
        public static readonly string MsgSituatie = @"Pe baza datelor selectate in zona alaturata se poate crea un model de regresie liniara care sa prezica urmatoarea medie de admitere a liceului selectat. De mentionat este faptul ca aceasta previzune nu este decat o alta unealta pentru calcularea sanselor de admitere. Datele pe care se calculeaza aceasta sansa pot sa fie limitate sau insuficiente pentru a garanta rata acuratetii.";
        public static readonly string MsgOptiune = @"Pentru a va usura munca de a cauta alte licee care s-ar potrivi cerintelor completate, am alcatuit o lista care ia in considerare crestrea mediilor si prezinta doar liceele pentru care exista o sansa considerabila de a fi admis. Acestea nu sunt singurele optiuni, dar reprezinta cele mai bune altrenative din punct de vedere matematic. Preferintele dumneavosta sunt pe primul loc.";
        public static readonly string MsgInfo1 = @"Pentru a putea folosi functionalitata de calcul a sansei de admitere la liceul dorit este recomandata completarea tuturor campurilor cu informatiile relevante.";
        public static readonly string MsgInfo2 = @"Pentru a putea folosi functionalitata de calcul a sansei de admitere la liceul dorit este recomandata completarea tuturor campurilor cu informatiile relevante.";
        public static readonly string MsgInfo3 = @"Pentru a putea folosi functionalitata de calcul a sansei de admitere la liceul dorit este recomandata completarea tuturor campurilor cu informatiile relevante.";
        public static readonly string MsgInfo4 = @"Pentru a putea folosi functionalitata de calcul a sansei de admitere la liceul dorit este recomandata completarea tuturor campurilor cu informatiile relevante.";


        public static List<string> InfoForUsers = new List<string>
            {
            "Pentru a putea folosi functionalitata de calcul a sansei de admitere la liceul dorit este recomandata completarea tuturor campurilor cu informatiile relevante.",
            "Informatiile completate in campurile din prima parte a ferestrei vor fi folosite strict pentru obtinerea unei estimari, acestea nu vor fi salvate.",
            "Rezultatul produs de calculul statistic nu trebuie sa fie singura sursa de informare pe care o folositi.",
            "Va rog pastrati in minte faptul ca aplicatia este in dezvoltare"
            };
    }
}
