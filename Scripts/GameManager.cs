using Godot;
using System;
using Godot.Collections;
using Newtonsoft.Json;

public class GameManager : Node2D
{
    public static string SAVE_PATH = "user://save.json";
    private DataModel _data = new DataModel();
    public string gameVersion;
    public int currentlevel;
    public int maxLevel;
    String menu = "res://Scenes/Levels/Menu.tscn";

    String[] levels = 
    {
        "res://Scenes/Levels/Level1.tscn",
        "res://Scenes/Levels/Level2.tscn",
        "res://Scenes/Levels/Level3.tscn",
        "res://Scenes/Levels/Level4.tscn",
        "res://Scenes/Levels/Level5.tscn",
        "res://Scenes/Levels/Level6.tscn",
        "res://Scenes/Levels/Level7.tscn",
        "res://Scenes/Levels/Level8.tscn",
        "res://Scenes/Levels/Level9.tscn"
    };

    public void loadLevel(int id)
    {
        if (id == -1)
            loadLevel("res://Scenes/Levels/Menu.tscn");
        else
            loadLevel(levels[id]);
    }

    private void loadLevel(String path)
    {
        try
        {
            GetTree().ChangeScene(path);
        } 
        catch
        {
            GD.Print("No Scene at " + path);
        }
    }

    public void updateData()
    {
        ReadSaveFile();
        currentlevel = _data.currentLevel;
        maxLevel = _data.maxLevel;
        if (currentlevel-1 > maxLevel)
            maxLevel = currentlevel-1;
    }

    public void Save()
    {
        if (currentlevel < 0 || currentlevel > 10)
            _data.currentLevel = 0;
        else
            _data.currentLevel = currentlevel;
        if (maxLevel < 0 || maxLevel > 10)
            _data.maxLevel = 0;
        else
            _data.maxLevel = maxLevel;
        WriteSaveFile();
    }

    private void ReadSaveFile()
    {
        string jsonString = null;
        var saveFile = OpenSaveFile(File.ModeFlags.Read);
        if (saveFile != null)
        {
            jsonString = saveFile.GetLine();
            try
            {
                _data = Deserialize(jsonString);
            }
            catch
            {
                _data = new DataModel();
            }
            saveFile.Close();
        }
    }


    private File OpenSaveFile(File.ModeFlags flag = File.ModeFlags.Read)
    {
        var saveFile = new File();
        var err = saveFile.Open(SAVE_PATH, (int) flag);
        if (err == 0)
            return saveFile;
        return null;
    }

    private void WriteSaveFile()
    {
        var saveFile = OpenSaveFile(File.ModeFlags.Write);
        if (saveFile != null)
        {
            var json = JsonConvert.SerializeObject(_data);
            saveFile.StoreLine(json);
            saveFile.Close();
        }
    }

    private DataModel Deserialize(string json)
    {
        return JsonConvert.DeserializeObject<DataModel>(json);
    }
}
