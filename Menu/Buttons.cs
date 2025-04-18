using StupidTemplate.Classes;
using StupidTemplate.Mods;
using static StupidTemplate.Settings;

namespace StupidTemplate.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Advantages", method =() => Advantages.EnterAdvanages(), isTogglable = false, toolTip = "Opens the advantages page."},
                new ButtonInfo { buttonText = "Visual", method =() => Visual.EnterVisual(), isTogglable = false, toolTip = "Opens the visual page."},
                new ButtonInfo { buttonText = "Fun", method =() => Fun.EnterFun(), isTogglable = false, toolTip = "Opens the fun page."},
                new ButtonInfo { buttonText = "Overpowered", method =() => Overpowered.EnterOverpowered(), isTogglable = false, toolTip = "Opens the overpowered page."},
                new ButtonInfo { buttonText = "Safety", method =() => Saftey.EnterSaftey(), isTogglable = false, toolTip = "Opens the Safety page."},
                new ButtonInfo { buttonText = "Movement", method =() => Movement.EnterMovement(), isTogglable = false, toolTip = "Opens the movement page."},
                new ButtonInfo { buttonText = "Cosmetics", method =() => Cosmetics.EnterCosmetics(), isTogglable = false, toolTip = "Opens the cosmetics page. (CS COSMETICS)"},
                new ButtonInfo { buttonText = "togglable placeholder 4"},
                new ButtonInfo { buttonText = "regular placeholder 5", isTogglable = false},
                new ButtonInfo { buttonText = "togglable placeholder 5"},
                new ButtonInfo { buttonText = "regular placeholder 6", isTogglable = false},
                new ButtonInfo { buttonText = "togglable placeholder 6"},
            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Latest Update?", method =() => SettingsMods.CheckVersion(), isTogglable = false, toolTip = "Checks if you have the latest version."},
                new ButtonInfo { buttonText = "Change Long arm length", method =() => SettingsMods.ChangeLongArmLength(), isTogglable = false, toolTip = " "},
                new ButtonInfo { buttonText = "Change Platform Type", method =() => SettingsMods.ChangePlatformType(), isTogglable = false, toolTip = " "},
            },

            new ButtonInfo[] { // Advantages Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
            },

            new ButtonInfo[] { // Projectile Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
            },
            new ButtonInfo[] { // Advantages
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "No tag freeze", method =() => Advantages.NoTagFreeze(), isTogglable = true, toolTip = "No tag freeze ever again!"},
                new ButtonInfo { buttonText = "WASD Fly", method =() => Advantages.WASDFly(), isTogglable = true},
                new ButtonInfo { buttonText = "Low Gravity", method =() => Advantages.LowGrav(), isTogglable = true, toolTip = "Low gravity"},
                new ButtonInfo { buttonText = "High Gravity", method =() => Advantages.HighGrav(), isTogglable = true, toolTip = "High gravity"},
                new ButtonInfo { buttonText = "Long Arms", enableMethod =() => Advantages.EnableLongArms(), disableMethod =() => Advantages.DisableLongArms(), toolTip = "Long arms (Changable in settings)"},
                new ButtonInfo { buttonText = "Weak Speed Boost", method =() => Advantages.WeakSpeedBoost(), isTogglable = true, toolTip = "Just a weak speed boost"},
                new ButtonInfo { buttonText = "GhostMonke", method =() => Advantages.GhostMonke(), isTogglable = true, toolTip = "Ghost monke"},
                new ButtonInfo { buttonText = "Normal Speed Boost", method =() => Advantages.NormalSpeedBoost(), isTogglable = true, toolTip = "Just a normal speed boost"},
                new ButtonInfo { buttonText = "Blatant Speed Boost", method =() => Advantages.BlatantSpeedBoost(), isTogglable = true, toolTip = "Just a blatant speed boost"},
                new ButtonInfo { buttonText = "Tag All (D?)", method =() => Advantages.TagAll(), isTogglable = true, toolTip = "Tag All"},
                new ButtonInfo { buttonText = "Fake Lag", method =() => Advantages.FakeLag(), isTogglable = true, toolTip = "Makes it look like your lagging"},
            },
            new ButtonInfo[] { // Visual
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Day Time", method =() => Visual.DayTime(), isTogglable = false, toolTip = "Day time"},
                new ButtonInfo { buttonText = "Night Time", method =() => Visual.NightTime(), isTogglable = false, toolTip = "Night time"},
                new ButtonInfo { buttonText = "Morning Time", method =() => Visual.MorningTime(), isTogglable = false, toolTip = "Morning time"},
                new ButtonInfo { buttonText = "Evening Time", method =() => Visual.EveningTime(), isTogglable = false, toolTip = "Evening time"},
                new ButtonInfo { buttonText = "Rectangle ESP", method =() => Visual.RectangleESP(), isTogglable = true, toolTip = "Rectangle ESP"},
            },
            new ButtonInfo[] { // Fun
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Hoverboard (D?) (SS?)", enableMethod =() => Fun.ShowHoverboard(), disableMethod =() => Fun.HideHoverboard(), toolTip = "Just hoverboard."},
                new ButtonInfo { buttonText = "Auto Middle Finger", method =() => Fun.AutoMiddleFinger(), isTogglable = true, toolTip = "Auto middle finger"},
                new ButtonInfo { buttonText = "Fast Hoverboard (D?) (NW)", enableMethod =() => Fun.FastHoverboard(), disableMethod =() => Fun.NormalHoverboard(), toolTip = "Fast hoverboard."},
                new ButtonInfo { buttonText = "No Tap Cooldown", enableMethod =() => Fun.NoTapCooldown(), disableMethod =() => Fun.NormalTapCooldown(), toolTip = "No tap cooldown"},
                new ButtonInfo { buttonText = "Loud Hand Taps", enableMethod =() => Fun.LoudHandTaps (), disableMethod =() => Fun.NormalHandTaps(), toolTip = "Loud hand taps"},
                new ButtonInfo { buttonText = "No hand taps", enableMethod =() => Fun.NoHandTaps (), disableMethod =() => Fun.NormalHandTaps(), toolTip = "No hand taps"},
                new ButtonInfo { buttonText = "Grab Bug", method =() => Fun.GrabBug(), isTogglable = true, toolTip = "Both grips grab bug."},
            },
            new ButtonInfo[] { // Overpowed
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Lag all (D?)", method =() => Overpowered.LagAll(), isTogglable = true, toolTip = "Lags everyone."},
                new ButtonInfo { buttonText = "Flush RPCS", method =() => Overpowered.FlushRPCS(), isTogglable = false},
                new ButtonInfo { buttonText = "Snowball Gun", method =() => Overpowered.SnowballGun(), isTogglable = true, toolTip = "Snow ball gun."},
                new ButtonInfo { buttonText = "No tag on join", enableMethod =() => Overpowered.NoTagOnJoin(), disableMethod =() => Overpowered.TagOnJoin(), toolTip = "Doesnt let you get tagged on join"},
                new ButtonInfo { buttonText = "Set Region to EU", method =() => Overpowered.RegionEU(), isTogglable = false, toolTip = "Sets your region to EU"},
                new ButtonInfo { buttonText = "Set Region to US", method =() => Overpowered.RegionUS(), isTogglable = false, toolTip = "Sets your region to US"},
                new ButtonInfo { buttonText = "Set Region to USW", method =() => Overpowered.RegionUSW(), isTogglable = false, toolTip = "Sets your region to USW"},
            },
            new ButtonInfo[] { // Saftey
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Anti Report", method =() => Saftey.AntiReport(), isTogglable = true, toolTip = "Doesnt let anyone report you."},
                new ButtonInfo { buttonText = "No finger movement", method =() => Saftey.NoFingerMovement(), isTogglable = true, toolTip = "No finger movement"},
                new ButtonInfo { buttonText = "Spoof Name", method =() => Saftey.SpoofName(), isTogglable = false, toolTip = " "},
                new ButtonInfo { buttonText = "Spam Spoof Name", method =() => Saftey.SpamSpoofName(), isTogglable = true, toolTip = " "},
                new ButtonInfo { buttonText = "Reconnect", method =() => Saftey.Reconnect(), isTogglable = false, toolTip = "Working?"},
            },
            new ButtonInfo[] { // Movement
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Swim everywhere", enableMethod =() => Movement.EnableSwimEverywhere(), disableMethod =() => Movement.DisableSwimEverywhere(), toolTip = "NW?"},
                new ButtonInfo { buttonText = "Platforms", method =() => Movement.Platforms(), isTogglable = true, toolTip = "Platforms." },
                new ButtonInfo { buttonText = "Super Slow Fly", method =() => Movement.SuperSlowFly(), isTogglable = true, toolTip = "Super Slow Fly." },
                new ButtonInfo { buttonText = "Slow Fly", method =() => Movement.SlowFly(), isTogglable = true, toolTip = "Slow Fly." },
                new ButtonInfo { buttonText = "Normal Fly", method =() => Movement.NormalFly(), isTogglable = true, toolTip = "Normal Fly." },
                new ButtonInfo { buttonText = "Up And Down", method =() => Movement.UpAndDown(), isTogglable = true, toolTip = "Right grab to go down, right trigger to go up" },
                new ButtonInfo { buttonText = "TP Gun", method =() => Movement.TpGun(), isTogglable = true, toolTip = "Working?" },
            },
            new ButtonInfo[] { // Cosmetics
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Early Access Badge", method =() => Cosmetics.EarlyAccessBadge(), isTogglable = false, toolTip = "Gives you CS Early Access badge."},
                new ButtonInfo { buttonText = "Finger Painter", method =() => Cosmetics.FingerPainter(), isTogglable = false, toolTip = "Gives you CS fingerpainter."},
                new ButtonInfo { buttonText = "Illustrator", method =() => Cosmetics.Illustator(), isTogglable = false, toolTip = "Gives you CS illustrator."},
                new ButtonInfo { buttonText = "Stick", method =() => Cosmetics.Stick(), isTogglable = false, toolTip = "Gives you CS stick."},
                new ButtonInfo { buttonText = "Admin Badge", method =() => Cosmetics.AdminBadge(), isTogglable = false, toolTip = "Gives you CS admin badge."},
            },
        };
    }
}
