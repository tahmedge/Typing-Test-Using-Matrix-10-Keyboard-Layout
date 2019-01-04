using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HCIKeyboardLayoutAndroid
{
    class Class1
    {
        public static string[] S = new string[100];
        
        public static string func()
        {
            S[0] = "WHAT A MONKEY SEES A MONKEY WILL DO";
            S[1] = "THE CHAMBER MAKES IMPORTANT DECISIONS";
            S[2] = "BANK TRANSACTION WAS NOT REGISTERED";
            S[3] = "THE PRESIDENTIAL SUITE IS VERY BUSY";
            S[4] = "THE PUNISHMENT SHOULD FIT THE CRIME";
            S[5] = "A THOROUGHLY DISGUSTING THING TO SAY";
            S[6] = "DID YOU SEE THAT SPECTACULAR EXPLOSION";
            S[7] = "KEEP RECEIPTS FOR ALL YOUR EXPENSES";
            S[8] = "WHERE DID YOU GET SUCH A SILLY IDEA";
            S[9] = "CONSTRUCTION MAKES TRAVELING DIFFICULT";
            S[10] = "THAT AGREEMENT IS RIFE WITH PROBLEMS";
            S[11] = "THAT LAND IS OWNED BY THE GOVERNMENT";
            S[12] = "BURGLARS NEVER LEAVE THEIR BUSINESS CARD";
            S[13] = "OUR HOUSEKEEPER DOES A THOROUGH JOB";
            S[14] = "HANDICAPPED PERSONS NEED CONSIDERATION";
            S[15] = "SALESMEN MUST MAKE THEIR MONTHLY QUOTA";
            S[16] = "SAVING THAT CHILD WAS AN HEROIC EFFORT";
            S[17] = "GRANITE IS THE HARDEST OF ALL ROCKS";
            S[18] = "EVERY SATURDAY HE FOLDS THE LAUNDRY";
            S[19] = "MICROSCOPES MAKE SMALL THINGS LOOK BIG";
            S[20] = "ONE NEVER TAKES TOO MANY PRECAUTIONS";
            S[21] = "SUBURBS ARE SPRAWLING UP EVERYWHERE";
            S[22] = "DOLPHINS LEAP HIGH OUT OF THE WATER";
            S[23] = "DINOSAURS HAVE BEEN EXTINCT FOR AGES";
            S[24] = "AN INJUSTICE IS COMMITTED EVERY DAY";
            S[25] = "LOOK IN THE SYLLABUS FOR THE COURSE";
            S[26] = "RECTANGULAR OBJECTS HAVE FOUR SIDES";
            S[27] = "THE TREASURER MUST BALANCE HER BOOKS";
            S[28] = "THE ACCIDENT SCENE IS A SHRINE FOR FANS";
            S[29] = "A TUMOR IS OK PROVIDED IT IS BENIGN";
            S[30] = "A MUCH HIGHER RISK OF GETTING CANCER";
            S[31] = "KNEE BONE IS CONNECTED TO THE THIGH BONE";
            S[32] = "SAFE TO WALK THE STREETS IN THE EVENING";
            S[33] = "THE ELEVATOR DOOR APPEARS TO BE STUCK";
            S[34] = "INSURANCE IS IMPORTANT FOR BAD DRIVERS";
            S[35] = "PUMPING HELPS IF THE ROADS ARE SLIPPERY";
            S[36] = "GUN POWDER MUST BE HANDLED WITH CARE";
            S[37] = "WEEPING WILLOWS ARE FOUND NEAR WATER";
            S[38] = "I CANNOT BELIEVE I ATE THE WHOLE THING";
            S[39] = "THE BIGGEST HAMBURGER I HAVE EVER SEEN";
            S[40] = "GAMBLERS EVENTUALLY LOOSE THEIR SHIRTS";
            S[41] = "IRREGULAR VERBS ARE THE HARDEST TO LEARN";
            S[42] = "THEY MIGHT FIND YOUR COMMENT OFFENSIVE";
            S[43] = "AN ENLARGED NOSE SUGGESTS YOU ARE A LIAR";
            S[44] = "IMPORTANT NEWS ALWAYS SEEMS TO BE LATE";
            S[45] = "PLEASE TRY TO BE HOME BEFORE MIDNIGHT";
            S[46] = "DORMITORY DOORS ARE LOCKED AT MIDNIGHT";
            S[47] = "QUESTIONING THE WISDOM OF THE COURTS";
            S[48] = "THAT REFERENDUM ASKED A SILLY QUESTION";
            S[49] = "A GOOD STIMULUS DESERVES A GOOD RESPONSE";
            S[50] = "EVERYBODY LOOSES IN CUSTODY BATTLES";
            S[51] = "THE PICKET LINE GIVES ME THE CHILLS";
            Random rnd = new Random();
            int val = rnd.Next(0, 17);
            return S[val];
        }
    }
}