# PingPlot
#### Author: Chris Campo (@ccampo133)
#### 2012

## Description
PlotPing is an open-source, network diagnostic tool that allows you to view your latency to some web address as a function of time.  It works by periodically pinging a user-decided URL or IP address, and logging the latency and send time of each echo request.  It also executes a trace-route in the pinging process, and displays the IP address of each intermediate router traversed during the ping.  The round-trip latencies are then plotted as a function of the times they were sent, and the graph is continuously updated.  The graph is color coded, with low latency pings displayed as green, mid latency pings as yellow, and high latency pings as red.  The application also allows you to save the data to a comma-separated-value file (.CSV) or a simple text file, for archival purposes.

If a network timeout occurs while the program is running, the graph will display red boxes as data points and the pings will be logged as -1, if you decide to save your data.

## Installation and Execution
PlotPing requires no installation if you are using the binary version.  Simply download the self-extracting executable from PlotPing's [download section](https://github.com/ccampo133/PlotPing/downloads) here on GitHub, and then run PlotPing.exe.  You must have the .NET 4.0 framework installed on your system for it to work.

If you want to build PlotPing from the source, you can either fork the PlotPing repo from me on GitHub or download the source as a zip file, and then build it using Visual Studio 2010.

## Motivation and Shout-Outs
PlotPing is useful for diagnosing network issues such as frequent disconnects or timeouts, as it allows you to see exactly when and where the timeouts occur.  Since the data is continuously logged, it can provide hard evidence to your ISP that your network is disconnecting (this was the main motivation for me to write this software).

It is also somewhat of a shameless, less-robust rip-off of [Nessoft's](http://www.nessoft.com/) [PingPlotter software](http://www.pingplotter.com/), so if you want something more sophisticated and of commercial calibre, please check out their software.  Check it out even if you are happy with my code!

Finally, if you are in the mood for a platform independent, much less robust but much more lightweight solution to PlotPing, check out my Python implementation of the same code, creatively named [PingPlot](https://github.com/ccampo133/PingPlot), here on GitHub.

## Support and Other Ramblings
Please make sure you have the .NET 4.0 framework installed on your system if you are having trouble running PlotPing.  If you have any problems, need any help, or better yet, find bugs, please email me at ccampo.progs@gmail.com, or contact me via GitHub (@ccampo133).  Alternatively you can submit any issues you encounter on [PlotPing's issues page](https://github.com/ccampo133/PlotPing/issues), right here on GitHub.

Also, this is literally my first ever project written for strictly for Windows using WinForms, and it is also my first time writing in C#.  I appologize if the code is a bit rough around the edges.  I will clean it up as I go on.  I also highly encourage anybody who looks at the code or uses the program to give me feedback, as it is invaluable to me.

Cheers, and happy pinging!  

## Screenshots
![](http://i.imgur.com/jdzbP.png)

![](http://i.imgur.com/rj6Hw.png)