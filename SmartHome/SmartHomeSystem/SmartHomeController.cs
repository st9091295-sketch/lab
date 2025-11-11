using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SmartHomeController
{
    private readonly List<ISwitchable> allDevices = new List<ISwitchable>();
    private readonly List<IEnergyConsumer> energyDevices = new List<IEnergyConsumer>();

    public void AddDevice(ISwitchable device)
    {
        allDevices.Add(device);
    }

    public void AddEnergyDevice(IEnergyConsumer device)
    {
        energyDevices.Add(device);
    }

    public void TurnAllOn()
    {
        foreach (var d in allDevices) d.TurnOn();
    }

    public void TurnAllOff()
    {
        foreach (var d in allDevices) d.TurnOff();
    }

    public void ShowEnergyReport(int hours)
    {
        var ua = new CultureInfo("uk-UA");
        Console.WriteLine($"Звіт про споживання енергії за {hours} год:");

        double total = 0;
        foreach (var d in energyDevices)
        {
            double used = d.GetEnergyUsage(hours);
            total += used;
            Console.WriteLine($"{d.DeviceName}: {used.ToString("F2", ua)} кВт·год (потужність: {d.PowerConsumption} Вт)");
        }

        Console.WriteLine($"Загальне споживання: {total.ToString("F2", ua)} кВт·год");
        double cost = total * 4;
        Console.WriteLine($"Вартість (~4 грн/кВт·год): {cost.ToString("F2", ua)} грн");
    }
}
