using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace TheraWii
{
    ///* All the structures in the wiiuse.h header file are included below. Quite
    // * a mess but I can't think of a better way to structure it */

    /**
     *	@struct vec2b_t
     *	@brief Unsigned x,y byte vector.
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct vec2b_t
    {
        public byte x, y;
    };

    /**
    *	@struct vec3b_t
    *	@brief Unsigned x,y,z byte vector.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct vec3b_t
    {
        public byte x, y, z;
    };

    /**
    *	@struct vec3f_t
    *	@brief Signed x,y,z float struct.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct vec3f_t
    {
        public float x, y, z;
    };

    /**
    *	@struct orient_t
    *	@brief Orientation struct.
    *
    *	Yaw, pitch, and roll range from -180 to 180 degrees.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct orient_t
    {
        public float roll;						/**< roll, this may be smoothed if enabled	*/
        public float pitch;					/**< pitch, this may be smoothed if enabled	*/
        public float yaw;

        float a_roll;					/**< absolute roll, unsmoothed				*/
        float a_pitch;					/**< absolute pitch, unsmoothed				*/
    };

    /**
    *	@struct gforce_t
    *	@brief Gravity force struct.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct gforce_t
    {
        public float x, y, z;
    };

    /**
    *	@struct accel_t
    *	@brief Accelerometer struct. For any device with an accelerometer.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct accel_t
    {
        vec3b_t cal_zero;		        /**< zero calibration					*/
        vec3b_t cal_g;			        /**< 1g difference around 0cal			*/

        public float st_roll;					/**< last smoothed roll value			*/
        public float st_pitch;					/**< last smoothed roll pitch			*/
        public float st_alpha;					/**< alpha value for smoothing [0-1]	*/
    };

    /**
    *	@struct ir_dot_t
    *	@brief A single IR source.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct ir_dot_t
    {
        public byte visible;					/**< if the IR source is visible		*/

        public uint x;					        /**< interpolated X coordinate			*/
        public uint y;				        	/**< interpolated Y coordinate			*/

        short rx;						/**< raw X coordinate (0-1023)			*/
        short ry;						/**< raw Y coordinate (0-767)			*/

        byte order;						/**< increasing order by x-axis value	*/

        byte size;						/**< size of the IR dot (0-15)			*/
    };

    /**
     *	@enum aspect_t
     *	@brief Screen aspect ratio.
     */
    enum aspect_t
    {
        WIIUSE_ASPECT_4_3,
        WIIUSE_ASPECT_16_9
    };
    /* IR correction types */
    enum ir_position_t
    {
        WIIUSE_IR_ABOVE,
        WIIUSE_IR_BELOW
    };

    /**
    *	@struct ir_t
    *	@brief IR struct. Hold all data related to the IR tracking.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct ir_t
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ir_dot_t[] dot;    			/**< IR dots							*/
        public byte num_dots;					            /**< number of dots at this time		*/

        aspect_t aspect;			                /**< aspect ratio of the screen			*/

        ir_position_t pos;			                /**< IR sensor bar position				*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] vres;			        /**< IR virtual screen resolution		*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public int[] offset;					/**< IR XY correction offset			*/
        public int state;						            /**< keeps track of the IR state		*/

        public int ax;							            /**< absolute X coordinate				*/
        public int ay;							            /**< absolute Y coordinate				*/

        public int x;							            /**< calculated X coordinate			*/
        public int y;							            /**< calculated Y coordinate			*/

        public float distance;					            /**< pixel distance between first 2 dots*/
        public float z;						            /**< calculated distance				*/
    };

    /**
    *	@struct joystick_t
    *	@brief Joystick calibration structure.
    *
    *	The angle \a ang is relative to the positive y-axis into quadrant I
    *	and ranges from 0 to 360 degrees.  So if the joystick is held straight
    *	upwards then angle is 0 degrees.  If it is held to the right it is 90,
    *	down is 180, and left is 270.
    *
    *	The magnitude \a mag is the distance from the center to where the
    *	joystick is being held.  The magnitude ranges from 0 to 1.
    *	If the joystick is only slightly tilted from the center the magnitude
    *	will be low, but if it is closer to the outter edge the value will
    *	be higher.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct joystick_t
    {
        public vec2b_t max;				/**< maximum joystick values	*/
        public vec2b_t min;				/**< minimum joystick values	*/
        public vec2b_t center;		    	/**< center joystick values		*/

        public float ang;					/**< angle the joystick is being held		*/
        public float mag;					/**< magnitude of the joystick (range 0-1)	*/
    };

    /**
    *	@struct nunchuk_t
    *	@brief Nunchuk expansion device.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct nunchuk_t
    {
        public accel_t accel_calib;		    /**< nunchuk accelerometer calibration		*/
        public joystick_t js;			        /**< joystick calibration					*/

        public IntPtr flags;				    /**< options flag (points to wiimote_t.flags) */

        public byte btns;						/**< what buttons have just been pressed	*/
        public byte btns_held;					/**< what buttons are being held down		*/
        public byte btns_released;				/**< what buttons were just released this	*/

        public float orient_threshold;			/**< threshold for orient to generate an event */
        public int accel_threshold;			/**< threshold for accel to generate an event */

        public vec3b_t accel;			        /**< current raw acceleration data			*/
        public orient_t orient;		    	/**< current orientation on each axis		*/
        public gforce_t gforce;			    /**< current gravity forces on each axis	*/
    };

    /**
    *	@struct classic_ctrl_t
    *	@brief Classic controller expansion device.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct classic_ctrl_t
    {
        public short btns;						/**< what buttons have just been pressed	*/
        public short btns_held;				/**< what buttons are being held down		*/
        public short btns_released;			/**< what buttons were just released this	*/

        public float r_shoulder;				/**< right shoulder button (range 0-1)		*/
        public float l_shoulder;				/**< left shoulder button (range 0-1)		*/

        public joystick_t ljs;	    	    	/**< left joystick calibration				*/
        public joystick_t rjs;		         	/**< right joystick calibration				*/
    };

    /**
    *	@struct balance_feet_t
    *	@brief Balance Board expansion data from 4-feet.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct balance_feet_t
    {
        public float fl, fr, bl, br;			/**< front-left, front-right, back-left, back-right */
    };

    /**
    *	@struct balance_board_t
    *	@brief Balance Board expansion device.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct balance_board_t
    {
        public balance_feet_t feet;		/**< weight on each foot, calibrated to kgs	*/
        balance_feet_t min;		    /**< calibration data						*/
        balance_feet_t center;	    /**< calibration data						*/
        balance_feet_t max;		    /**< calibration data						*/
    };

    /* expansion codes */
    public enum WiiExpansion
    {
        EXP_NONE = 0,
        EXP_NUNCHUK = 1,
        EXP_CLASSIC = 2,
        EXP_GUITAR_HERO_3 = 3,
        EXP_BALANCE = 4
    }

    /**
    *	@struct expansion_t
    *	@brief Generic expansion device plugged into wiimote.
    * 
    * TODO: How do we represent the C union in C#???
    */
    [StructLayout(LayoutKind.Explicit)]
    public struct expansion_t
    {
        [FieldOffset(0)]
        public WiiExpansion type;						/**< type of expansion attached				*/

        /* Union */
        [FieldOffset(sizeof(int))]
        public nunchuk_t nunchuk;
        [FieldOffset(sizeof(int))]
        public classic_ctrl_t classic;
        [FieldOffset(sizeof(int))]
        public balance_board_t balance;
    };

    /**
    *	@enum win32_bt_stack_t
    *	@brief	Available bluetooth stacks for Windows.
    */
    public enum win_bt_stack_t
    {
        WIIUSE_STACK_UNKNOWN,
        WIIUSE_STACK_MS,
        WIIUSE_STACK_BLUESOLEIL
    };

    /**
    *	@struct wiimote_state_t
    *	@brief Significant data from the previous event.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct wiimote_state_t
    {
        /* expansion_t */
        float exp_ljs_ang;
        float exp_rjs_ang;
        float exp_ljs_mag;
        float exp_rjs_mag;
        ushort exp_btns;
        orient_t exp_orient;
        vec3b_t exp_accel;
        float exp_r_shoulder;
        float exp_l_shoulder;

        /* ir_t */
        int ir_ax;
        int ir_ay;
        float ir_distance;

        orient_t orient;
        ushort btns;

        vec3b_t accel;
    };

    /**
    *	@enum WIIUSE_EVENT_TYPE
    *	@brief Events that wiiuse can generate from a poll.
    */
    public enum WIIUSE_EVENT_TYPE
    {
        WIIUSE_NONE = 0,
        WIIUSE_EVENT,
        WIIUSE_STATUS,
        WIIUSE_CONNECT,
        WIIUSE_DISCONNECT,
        WIIUSE_UNEXPECTED_DISCONNECT,
        WIIUSE_READ_DATA,
        WIIUSE_NUNCHUK_INSERTED,
        WIIUSE_NUNCHUK_REMOVED,
        WIIUSE_CLASSIC_CTRL_INSERTED,
        WIIUSE_CLASSIC_CTRL_REMOVED,
        WIIUSE_GUITAR_HERO_3_CTRL_INSERTED,
        WIIUSE_GUITAR_HERO_3_CTRL_REMOVED,
        WIIUSE_BALANCE_BOARD_INSERTED,
        WIIUSE_BALANCE_BOARD_REMOVED
    };

    /**
    *	@struct wiimote_t
    *	@brief Wiimote structure.
    * 
    *   NOTE: The variable WIIUSE_EVENT_TYPE e is originally called WIIUSE_EVENT_TYPE event in wiiuse.h
    *   but event is a reserved keyword in C#. Hopefully changing this here will not cause a massive
    *   failure later. Also, dev_handle was originally of type HANDLE, but I read online it can be used
    *   as IntPtr so we'll go with that for now. Same goes for hid_overlap.
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct wiimote_t
    {
        public int unid;						        /**< user specified id						*/
        private IntPtr dev_handle;			            /**< HID handle								*/
        private NativeOverlapped hid_overlap;           /**< overlap handle							*/
        public win_bt_stack_t stack;                   /**< type of bluetooth stack to use			*/
        public int timeout;                            /**< read timeout							*/
        public byte normal_timeout;                    /**< normal timeout							*/
        public byte exp_timeout;                       /**< timeout for expansion handshake		*/
        public int state;						        /**< various state flags					*/
        public byte leds;						        /**< currently lit leds						*/
        public float battery_level;			            /**< battery level							*/
        public int flags;						        /**< options flag							*/
        public byte handshake_state;			        /**< the state of the connection handshake	*/
        public IntPtr read_req;		                    /**< list of data read requests				*/
        public accel_t accel_calib;		                /**< wiimote accelerometer calibration		*/
        public expansion_t exp;			                /**< wiimote expansion device				*/
        public vec3b_t accel;			                /**< current raw acceleration data			*/
        public orient_t orient;		            	    /**< current orientation on each axis		*/
        public gforce_t gforce;			                /**< current gravity forces on each axis	*/
        public ir_t ir;					                /**< IR data								*/
        public ushort btns;				                /**< what buttons have just been pressed	*/
        public ushort btns_held;		                /**< what buttons are being held down		*/
        public ushort btns_released;	                /**< what buttons were just released this	*/
        public float orient_threshold;			        /**< threshold for orient to generate an event */
        public int accel_threshold;				        /**< threshold for accel to generate an event */
        public wiimote_state_t lstate;	                /**< last saved state						*/
        public WIIUSE_EVENT_TYPE eventw;			            /**< type of event that occured				*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] event_buf;	                    /**< event buffer							*/
    };
    /* End of the structures, should be able to use everything from the wiiuse.h file at this point
     * since all the structs are defined(I hope) above. */

    class WiiUseC
    {
        /* led bit masks */
        public const int WIIMOTE_LED_NONE = 0x00;
        public const int WIIMOTE_LED_1 = 0x10;
        public const int WIIMOTE_LED_2 = 0x20;
        public const int WIIMOTE_LED_3 = 0x40;
        public const int WIIMOTE_LED_4 = 0x80;

        /* button codes */
        public const int WIIMOTE_BUTTON_TWO = 0x0001;
        public const int WIIMOTE_BUTTON_ONE = 0x0002;
        public const int WIIMOTE_BUTTON_B = 0x0004;
        public const int WIIMOTE_BUTTON_A = 0x0008;
        public const int WIIMOTE_BUTTON_MINUS = 0x0010;
        public const int WIIMOTE_BUTTON_ZACCEL_BIT6 = 0x0020;
        public const int WIIMOTE_BUTTON_ZACCEL_BIT7 = 0x0040;
        public const int WIIMOTE_BUTTON_HOME = 0x0080;
        public const int WIIMOTE_BUTTON_LEFT = 0x0100;
        public const int WIIMOTE_BUTTON_RIGHT = 0x0200;
        public const int WIIMOTE_BUTTON_DOWN = 0x0400;
        public const int WIIMOTE_BUTTON_UP = 0x0800;
        public const int WIIMOTE_BUTTON_PLUS = 0x1000;
        public const int WIIMOTE_BUTTON_ZACCEL_BIT4 = 0x2000;
        public const int WIIMOTE_BUTTON_ZACCEL_BIT5 = 0x4000;
        public const int WIIMOTE_BUTTON_UNKNOWN = 0x8000;
        public const int WIIMOTE_BUTTON_ALL = 0x1F9F;

        /* nunchul button codes */
        public const int NUNCHUK_BUTTON_Z = 0x01;
        public const int NUNCHUK_BUTTON_C = 0x02;
        public const int NUNCHUK_BUTTON_ALL = 0x03;

        /* classic controller button codes */
        public const int CLASSIC_CTRL_BUTTON_UP = 0x0001;
        public const int CLASSIC_CTRL_BUTTON_LEFT = 0x0002;
        public const int CLASSIC_CTRL_BUTTON_ZR = 0x0004;
        public const int CLASSIC_CTRL_BUTTON_X = 0x0008;
        public const int CLASSIC_CTRL_BUTTON_A = 0x0010;
        public const int CLASSIC_CTRL_BUTTON_Y = 0x0020;
        public const int CLASSIC_CTRL_BUTTON_B = 0x0040;
        public const int CLASSIC_CTRL_BUTTON_ZL = 0x0080;
        public const int CLASSIC_CTRL_BUTTON_FULL_R = 0x0200;
        public const int CLASSIC_CTRL_BUTTON_PLUS = 0x0400;
        public const int CLASSIC_CTRL_BUTTON_HOME = 0x0800;
        public const int CLASSIC_CTRL_BUTTON_MINUS = 0x1000;
        public const int CLASSIC_CTRL_BUTTON_FULL_L = 0x2000;
        public const int CLASSIC_CTRL_BUTTON_DOWN = 0x4000;
        public const int CLASSIC_CTRL_BUTTON_RIGHT = 0x8000;
        public const int CLASSIC_CTRL_BUTTON_ALL = 0xFEFF;

        /* guitar hero 3 button codes */
        public const int GUITAR_HERO_3_BUTTON_STRUM_UP = 0x0001;
        public const int GUITAR_HERO_3_BUTTON_YELLOW = 0x0008;
        public const int GUITAR_HERO_3_BUTTON_GREEN = 0x0010;
        public const int GUITAR_HERO_3_BUTTON_BLUE = 0x0020;
        public const int GUITAR_HERO_3_BUTTON_RED = 0x0040;
        public const int GUITAR_HERO_3_BUTTON_ORANGE = 0x0080;
        public const int GUITAR_HERO_3_BUTTON_PLUS = 0x0400;
        public const int GUITAR_HERO_3_BUTTON_MINUS = 0x1000;
        public const int GUITAR_HERO_3_BUTTON_STRUM_DOWN = 0x4000;
        public const int GUITAR_HERO_3_BUTTON_ALL = 0xFEFF;


        /* wiimote option flags */
        public const int WIIUSE_SMOOTHING = 0x01;
        public const int WIIUSE_CONTINUOUS = 0x02;
        public const int WIIUSE_ORIENT_THRESH = 0x04;
        public const int WIIUSE_INIT_FLAGS = (WIIUSE_SMOOTHING | WIIUSE_ORIENT_THRESH);

        public const float WIIUSE_ORIENT_PRECISION = 100.0f;

        /* expansion codes */
        public const int EXP_NONE = 0;
        public const int EXP_NUNCHUK = 1;
        public const int EXP_CLASSIC = 2;
        public const int EXP_GUITAR_HERO_3 = 3;
        public const int EXP_BALANCE = 4;

        /**
         *	@brief Check if a button is pressed.
         *	@param dev		Pointer to a wiimote_t or expansion structure.
         *	@param button	The button you are interested in.
         *	@return 1 if the button is pressed, 0 if not.
         */
        public static bool IS_PRESSED(wiimote_t dev, int button) { return ((dev.btns & button) == button); }

        /* try to import the dll and all its functions so we can use them here */
        [DllImport("wiiuse.dll")]
        public static extern string wiiuse_version();

        [DllImport("wiiuse.dll")]
        public static extern IntPtr wiiuse_init(int wiimotes);

        [DllImport("wiiuse.dll")]
        public static extern int wiiuse_find(IntPtr wm, int max_wiimotes, int timeout);

        [DllImport("wiiuse.dll")]
        public static extern int wiiuse_connect(IntPtr wms, int wiimotes);

        [DllImport("wiiuse.dll")]
        public static extern void wiiuse_set_leds(IntPtr wm, int leds);

        [DllImport("wiiuse.dll")]
        public static extern void wiiuse_cleanup(IntPtr wm, int wiimotes);

        [DllImport("wiiuse.dll")]
        public static extern int wiiuse_poll(IntPtr wms, int wiimotes);

        [DllImport("wiiuse.dll")]
        public static extern void wiiuse_motion_sensing(IntPtr wm, int status);

        [DllImport("wiiuse.dll")]
        public static extern void wiiuse_set_ir(IntPtr wm, int status);
    }
}