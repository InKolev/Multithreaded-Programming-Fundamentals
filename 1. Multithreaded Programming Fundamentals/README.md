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
- [Context-switching](#contextSwitching)
 - [Cooperative multitasking (Fibers)](#cooperativeMultitasking)
 - [Preemptive multitasking (Threads)](#preemptiveMultitasking)
- [Multithreading Use-Cases](#useCases)
- [Multithreading caveats](#caveats)



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Table of Contents - II
- [Creating and Starting threads](#creatingAndStartingThreads)
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
# Process vs. Thread
## What is a Process / Thread? <br/> What is Multitasking / Multithreading?



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is a Process?
 - In terms of computing - a process is an **instance** of a **computer program** that is being **executed**.  
 - It contains the **program code** and its **current activity**.   
 - Depending on the **OS**, a process may be made up of **multiple threads of execution**, that execute instructions <a href="https://en.wikipedia.org/wiki/Concurrency_(computer_science)">_concurrently_</a>.



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is a Process?
 - A computer program is a _**passive collection**_ of instructions, while a process is the _**actual execution**_ of those instructions.   
 - _**Several processes**_ may be associated with the _**same program**_. For example, opening up several instances of the same program (Visual Studio, Google Chrome, etc), often means more than one process is being executed.



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is a Process?
 - Each process **provides the resources** needed to execute a program.
 - Each process is started with a **single thread of execution**, often called the **primary thread**, and can create additional threads from any of its threads.



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is a Process?
 - A process has a:
  - **Virtual address space**
  - **Executable code**
  - **Open handles to system objects** & **security context**
  - **Unique process identifier**
  - **Environment variables** & **priority class**
  - **At least one thread of execution**.



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is a Thread?
 - A thread is an **entity within a process** that can be **scheduled** for execution.
 - All threads of a **process** share its **virtual address space** and system resources.
 - Each thread maintains **exception handlers**, a **scheduling priority**, thread **local storage**, a unique **thread identifier**, and a **set of structures** the system will use to save the **thread context** until it is **scheduled**.



 <!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is a Thread?
 - The **thread context** includes:
	 - **The thread's set of machine registers**
	 - **The kernel stack**
	 - **A thread environment block (TEB)**
	 - **A user stack in the address space of the thread's process**.
 - Threads can also have their own **security context**, which can be used for impersonating clients.



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is Multitasking?
 - <a href="https://en.wikipedia.org/wiki/Computer_multitasking">_**Multitasking**_</a> is a concept of **performing multiple tasks** (processes) over a certain **period of time** by executing them in a **parallel** manner or **concurrently**.  
 - **New tasks start** and **interrupt already started ones** before they have reached completion, **instead of executing the tasks sequentially** so each started task needs to reach its end before a new one is started.  



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is Multitasking?
 - The tasks share common processing resources such as central processing units **(CPUs)** and **main memory**.
 - Multitasking does not necessarily mean that multiple tasks are executing at exactly the same time. **Multitasking does not imply parallel execution**, but it does mean that more than one task can be **part-way** through execution at the same time, and that **more than one task** is **advancing** over a given period of time.



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is Multithreading?
Multithreading **extends the idea of multitasking** into applications, so you can **subdivide specific operations** within a **single application** into individual threads. Each of the threads can run in **parallel**. **The OS divides processing time** not only **among different applications**, but also **among each thread within an application**.



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is Multithreading?
A common example of the **advantage of multithreading** is the fact that you can have a **word processor** that **prints a document** using a background thread, but at the same time another thread is running that **accepts user input**, so that you can type up a new document.



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Summary
**Multitasking** is the **ability of an OS** to run **several tasks**(processes) at the **same time**. Switching between the tasks is so fast that the user can interact fully with the system, **without having to wait for one task to be completely finished**.



<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Summary
**Multithreading** is the **ability of an OS** to execute **different parts of a program**, called threads, **concurrently**. Multithreading usually involves very sophisticated programs that use multiple CPUs at the same time to **improve performance and responsiveness**. A computer that has multiple CPUs but does not have applications written specifically to use multiprocessing or multithreading uses just one CPU.


<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
Two puzzles, one kid






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
