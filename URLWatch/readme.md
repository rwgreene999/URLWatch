# URLWatch

## Description
Used to repeatable monitor a URL, keep track of the response times, and chart the results.  Used as a keepalive and to track bad response

Running: ![](https://github.com/rwgreene999/URLWatch/URLWatch/Info/Running.png)

Chart: ![](https://github.com/rwgreene999/URLWatch/URLWatch/Info/ChartExample.png)

## Technology 
This is a windows WPF application utilizing Framework 4.6x and c# v6 or higher. MahApps.Metro is utilized for a better apperavce and LiveCharts is used for the charting. 

## Todos 
1. Change interface between GUI and working parts to BackGround worker thread or MVVM or other
2. Update GUI when URL checking and pausing between checks 
3. Redo GUI apperance using StackPanel instead of Grid 
4. Creation of data for LiveCharts seems to be a hack, I think there shoudl be a better way 
5. Change LiveCharts to be live, updating with fresh data for each new URL check
6. Add chart overlay of not found or timeouts 
7. Add saome icons to make it look more professional 
8. Spend some time making the LiveChart look better, add URL to title, name it as milliseconds, ... 
9. Add option to start when Windos Starts
10. Add option to minimize to tray
11. Add option to start minimized 
12. Add option to remove the first URL response after 10 checks or so because the first one takes longer and skews the results 

