<!-- section start -->
<!-- attr: { id:'', class:'slide-title', showInPresentation:true, hasScriptWrapper:true } -->
# Multithreaded programming: Fundamentals
## Brief overview and concepts, Creating and starting threads, Threads synchronization, Locking shared resources, Thread states

<div class="signature">
	<p class="signature-course">Multithreaded programming</p>
	<p class="signature-initiative">Telerik Academy Plus</p>
	<a href="http://academy.telerik.com/seminars/software-engineering/" class="signature-link">http://academy.telerik.com/seminars</a>
</div>



<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Table of Contents
## What will we cover?


<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Table of Contents - I
- [Brief overview and concepts](#overview)
- [Process vs. Thread](#processVsThread)
- [Multithreading Use-Cases](#useCases)
- [Demo: Unresponsive UI](#demoUnresponsiveUi)
- [Multithreading caveats](#caveats)



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Table of Contents - II
- [Creating and Starting threads](#creatingAndStartingThreads)
- [Demo: Starting threads](#demoStartingThreads)
- [Thread entry point methods](#threadEntryPointMethods)
- [Thread lifetime](#threadLifetime)
- [Naming threads](#namingThreads)
- [Background threads](#backgroundThreads)
- [Thread priority](#threadPriority)



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Table of Contents - III
- [Race condition](#raceCondition)
- [Synchronizing threads](#synchronizingThreads)
- [Blocking Threads](#blockingThreads)
- [Sleeping and Spinning Threads](#sleepingAndSpinning)
- [Joining a Thread](#joiningThreads)
- [The "volatile" keyword](#volatileKeyword)
- [Interrupt and Abort](#interruptAndAbort)
- [Locking shared resources](#lockingSharedResources)



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Table of Contents - IV
- [Thread States](#threadStates)
	- [Unstarted](#unstartedState)
	- [Running](#runningState)
	- [Blocked](#blockedState)
	- [Interrupted](#interruptedState)
	- [Stopped/StopRequested](#stoppedState)
	- [Suspended/SuspendRequested](#suspendedState)
	- [Aborted/AbortRequested](#abortedState)
	- [Background](#isBackgroundState)



<!-- section start -->
<!-- attr: { id:'overview', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# <a id="overview"></a> Brief overview
## Understanding asynchronous and <br/> parallel work



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Overview and Concepts
**Firefighters Rescue Team** example:  
 - Single firefighter, single victim (_**Trivial**_)  
 - Many firefighters, single victim (_**Parallel**_)  
 - Single firefighter, many victims (_**Two ways to deal with the problem**_)
	 - Fully saving the **first** victim, then the **second** one, then the **n-th** one... (_**Synchronous**_)  
	 - Help a single victim for a **given time**, then **switch to help** another. Repeat until all of the victims are safe (_**Asynchronous**_)    



<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# <a id=""></a> Sum of all numbers in a given interval
## [Demo:]()


<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->

<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->

<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->












<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
- Single processor core, single interval (**Trivial**)
- Many processor cores, single interval (**Parallel**)
- Single processor core, many intervals (**Two ways to deal with the problem**)
	- Sum the numbers from the first interval, then from the second, then from the n-th... (**Synchronous**)
	- Sum the numbers from an interval for a **given time**, then **switch to serve another. Repeat till done. (**Asynchronous**)

<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
# Free Trainings @ Telerik Academy
- C# Programming @ Telerik Academy
    - csharpfundamentals.telerik.com
  - Telerik Software Academy
    - academy.telerik.com
  - Telerik Academy @ Facebook
    - facebook.com/TelerikAcademy
  - Telerik Software Academy Forums
    - telerikacademy.com/Forum/Home  

<!-- <img class="slide-image" showInPresentation="true" src="imgs\pic55.png" style="top:40%; left:68%; width:36.30%; z-index:-1; border: 1px solid white; border-radius:5px;" /> -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs\pic57.png" style="top:60%; left:92%; width:13.01%; z-index:-1" /> -->
