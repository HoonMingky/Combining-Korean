private string ConvertedName(string name)
{
    var combiningChar = 0;
    List<char> afterText = new List<char>();
    for(var i = 0; i < name.Length; i++)
    {
        var temp = name[i];
        if (temp >= 4352 && temp < 4449)
        {
            if (combiningChar > 0)
            {
                if(combiningChar < 2016)
                {
                    combiningChar = combiningChar / 21 + 4352;
                }
                else
                {
                    combiningChar += 44032;
                }
                afterText.Add((char)combiningChar);
                combiningChar = 0;
            }
            combiningChar += temp - 4352;
            combiningChar *= 21;
        }
        else if(temp >= 4449 && temp < 4519)
        {
            if(combiningChar > 0)
            {
                combiningChar += temp - 4449;
                combiningChar *= 28;
            }
            else
            {
                afterText.Add(temp);
            }
            
        }
        else if(temp >= 4519 && temp < 4601)
        {
            if(combiningChar > 0)
            {
                combiningChar += temp - 4519;
            }
            else
            {
                afterText.Add(temp);

            }
        }
        else
        {
            if (combiningChar > 0)
            {
                if (combiningChar < 2016)
                {
                    combiningChar = combiningChar / 21 + 4352;
                }
                else
                {
                    combiningChar += 44032;
                }
                afterText.Add((char)combiningChar);
                combiningChar = 0;

            }
            afterText.Add(temp);
        }
    }
    if (combiningChar > 0)
    {
        if (combiningChar < 2016)
        {
            combiningChar = combiningChar / 21 + 4352;
        }
        else
        {
            combiningChar += 44032;
        }
        afterText.Add((char)combiningChar);
        combiningChar = 0;
    }
return new string(afterText.ToArray());
}
