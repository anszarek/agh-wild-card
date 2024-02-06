using System.Collections.Generic;

public static class Constants
{
    /**********************
     * STRINGS
     **********************/
    public const string RIGHT = "right";
    public const string LEFT = "left";
    public const string ICON = "Icon";
    public const string CHOOSED = "Choosed";
    public static string SHOW = "show";
    public const string CAMERA = "Camera";
    public const string DOOR = "Door";
    public const string LOCKED_DOOR = "LockedDoor";
    public const string ITEM = "Item";
    public const string LAPTOP = "Laptop";
    public const string WHOAMI = "whoami";
    public const string BOARD = "Board";
    public const string AKITA = "select id from users where username = 'akita';";
    public const string COLOR = "select color from jackets where user_id = 48;";
    public const string CHANGE_SCENE = "changeScene";
    public const string ELECTRONIC_LOCK = "ElectronicLock";
    public const string KEY = "Key";
    public const string CODE_TO_LECTURE = "7749";
    public const string CODE_TO_COMPUTER_ROOM = "4637";
    public const string KEY_PRESSED = "keyPressed";
    public const string CHAIR_WITH_KEY = "ChairWithKey";
    public const string FOCUS = "Focus";
    public const string FIRST_FLOOR = "Floor1";
    public const string FOURTH_FLOOR = "Floor4";
    public const string ERROR = "Error";
    public const string LOCKER = "Locker";
    public const string DRAWER = "Drawer";
    public const string TRASHCANWITHPASSWORD = "TrashcanWithPassword";
    public const string RUBBISH = "Rubbish";
    public const string MONITOR = "Monitor";
    public const string PENDRIVE = "Pendrive";
    public const string NEXT = "Next";
    public const string PASSWORD = "AGH_wiet*#d17";
    public const string JACKET = "Jacket";
    public const string HINT = "Hint";
    public const string FLAP = "Flap";
    public const string SCREW = "Screw";
    public const string STARTPUZZLE = "StartPuzzle";
    public const string QR = "Qr";

    /**********************
     * FLOATS
     **********************/
    public const float ROTATION_THRESHOLD = 200f;
    public const float TRANSITION_TIME = 0.5f;
    public const float OPEN_LOCKED_DOOR_TIME = 3.3f;

    /**********************
     * INTS
     **********************/
    public const int NONE = -1;
    public const int MAX_CODE_LENGTH = 6;
    public const int DELETE_NUMBER = -1;
    public const int CHECK_CODE = 10;
    public const int ELEVATOR_HALL_ID = 6;
    public const int COMPUTER_HALL_ID = 8;
}
