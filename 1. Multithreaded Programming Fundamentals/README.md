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
- [Parallel vs Concurrent vs Async](#concurrencyVsParallelism)
- [Process vs. Thread](#processVsThread)
- [Multitasking vs. Multithreading](#multitaskingVsMultithreading)
 - [Cooperative multitasking](#cooperativeMultitasking)
 - [Preemptive multitasking](#preemptiveMultitasking)
- [Multithreading use-cases](#useCases)
- [Multithreading caveats](#caveats)




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Table of Contents - II
- [Creating and Starting threads](#creatingAndStartingThreads)
- [Parameterized Thread Start](#parameterizedThreadStart)
- [Naming threads](#namingThreads)
- [Background threads](#backgroundThreads)
 - [a.k.a Daemon threads](#daemonThreads)
- [Threads lifetime](#threadLifetime)
- [Thread priority](#threadPriority)
- [Joining a Thread](#joiningThreads)




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Table of Contents - III
- [Race condition](#raceCondition)
- [Critical sections](#synchronizingThreads)
- [Locking shared resources](#lockingSharedResources)
- [The tricky "volatile" keyword](#volatileKeyword)




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Table of Contents - IV
- [Thread States](#threadStates)
	- [Unstarted](#unstartedState)
	- [Running](#runningState)
	- [Blocked](#blockedState)
	- [Interrupted](#interruptedState)
	- [StopRequested/Stopped](#stoppedState)
	- [SuspendRequested/Suspended](#suspendedState)
	- [AbortRequested/Aborted](#abortedState)




<!-- section start -->
<!-- attr: { id:'overview', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# <a id="overview"></a> Brief overview
## Understanding asynchronous, parallel and concurrent work




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style: 'font-size:0.8em;' } -->
# Synchronous work
In order to understand what Asynchronous programming is, we must have a clear definition for what **Synchronous programming** is:
- **Sequential** execution of code statements.
- If a blocking operation occurs, the whole process is blocked.
- If a long-running operation occurs, the UI becomes unresponsive.
- CPU-demanding tasks delay the execution of all other tasks.
- Accessing external resources blocks the entire process (reading files from the HDD, querying a web service, etc).




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style: 'font-size:0.8em;' } -->
# Synchronous work
**Example:**
- A man is doing presentation for work.
- His wife starts asking random questions, just to get his attention.
- A man can't give attention, because he maxed out his CPU resources on the work he is currently doing, so he is not-responding back to his wife. He is not even listening to what she says.
- After his work is completed, he turns around with a cute smile and asks his wife - "Whatsup? :)", but he has no idea that 30 seconds ago with his silence he accidentally opened Pandora's box.




<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Freezing UI
## Live demo




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style: 'font-size: 0.8em;' } -->
# Asynchronous work
- In general, asynchronous (from Greek asyn-, meaning "not with," and chronos, meaning "time") is an adjective describing objects or events that are not coordinated in time.

- In computer programs, asynchronous operation means that a process operates independently of other processes.

- A program using asynchronous programming, dispatches tasks to devices that can take care of themselves, leaving the program free to do something else until it receives a signal that the work is completed.


<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style: 'font-size:0.9em;' } -->
# Asynchronous work
- **Example:** A woman sits in a cafeteria and orders a coffee. While waiting for her coffee to be served, she is reading the morning newspaper.

<!-- <img showInPresentation="true" class="slide-image" src="images/Async.png" style="top:34%; left:4%; width:65%; z-index:-1; border-radius: 5px; border: 1px solid white;" /> -->
</br>
</br>
</br>
</br>
</br>
</br>
</br>
- Not this one though, she already has a coffee.




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style: 'font-size:0.9em;' } -->
# Asynchronous work
- Example: This guys is asynchronously doing his laundry while reading Twilight.

<!-- <img showInPresentation="true" class="slide-image" src="images/Async2.jpg" style="top:28%; left:4%; width:65%; z-index:-1; border-radius: 5px; border: 1px solid white;" /> -->
</br>
</br>
</br>
</br>
</br>
</br>
</br>




<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Responsive UI
## Live demo




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style: 'font-size:0.9em;' } -->
# Parallel work
- In parallel computing, a computational task is typically **broken down in several**, often many, very similar **subtasks** that can be **processed independently** and whose results are combined afterwards, upon completion.
- The tasks advance simultaneously - that is **literally at the same time**.




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style: 'font-size:0.9em;' } -->
# Parallel work
**Examples**:
- A logistics company uses many transport vehicles in order to complete the deliveries as fast as possible.
- An accounting company has many employees that do calculations for multiple clients simultaneously.

Parallel programs distribute their tasks to multiple processors, that actively work on all of them simultaneously.

[Video](https://www.youtube.com/watch?v=3nbjhpcZ9_g)



<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# <a id=""></a> Sum problem
## [Live demo]()




<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# <a id=""></a> Sum of all numbers in a given interval
## [Demo]()




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style: 'font-size:0.9em;' } -->
# Concurrent work
- Concurrent computing is a form of computing in which several computations are executed during overlapping time periods—concurrently—instead of sequentially.
- There is a separate execution point or "thread of control" for each computation ("process").
- A concurrent system is one where a computation can advance without waiting for all other computations to complete; where more than one computation can advance at the "same time".




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style: 'font-size:0.9em;' } -->
# Concurrent work
- Concurrent programs handle tasks that are all progressing at the same time, but it is only necessary to work briefly and separately on each task, so the work can be interleaved in whatever order the tasks require.

- Example: [A man juggling with one hand](https://www.youtube.com/watch?v=9uMui692JHU)




<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Concurrency vs. Parallelism
## Diffrences between concurrency and parallelism




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Concurrency vs Parallelism
 - Concurrency is about **dealing** with lots of things at once.
 - Parallelism is about **doing** lots of things at once
 - Not the same concepts, but **related**
 - One is about structure, one is about execution




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Quote
"In programming, **concurrency** is the composition of **independently executing processes**,  
while **parallelism** is the **simultaneous execution** of (possibly related) computations."  
\- Andrew Gerrand -  

<br/>
[Rob Pike: "Concurrency is not Parallelism" (Video)](https://vimeo.com/49718712)





<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Process vs. Thread




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is a Process?
 - In terms of computing - a process is an **instance** of a **computer program** that is being **executed**.  
 - It contains the **program code** and its **current activity (state)**.   
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




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style: 'font-size:0.9em;' } -->
# Process anatomy<br> Summary
 - A process is an inert container
  - It defines a virtual address space.
	 - Contents are not addressable from another processes.
  - Libraries of code are mapped into the address space.
	 - 1 EXE + N DLLs (dynamically loaded libraries)

<!-- <img showInPresentation="true" class="slide-image" src="images/ProcessAnatomy1.png" style="top:57%; left:8%; width:80%; z-index:-1; border-radius: 5px; border: 1px solid white;" /> -->




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style: 'font-size:0.9em;' } -->
# Thread anatomy<br> Summary
- `Threads` execute code
 - A thread is a path of execution within a single process.
 - It has access to all of the data within that process.
 - Each thread has its own callstack & copy of the CPU registers
 - A process with no threads exits (because it can no longer perform work)

<!-- <img showInPresentation="true" class="slide-image" src="images/ThreadAnatomy1.png" style="top:62%; left:40%; width:27%; z-index:-1; border-radius: 5px; border: 1px solid white;" /> -->
<!-- section start -->




<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Multithreading vs. Multitasking




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is Multitasking?
 - <a href="https://en.wikipedia.org/wiki/Computer_multitasking">_**Multitasking**_</a> is a concept of **performing multiple tasks** (processes) over a certain **period of time** by executing them in a **parallel** manner or **concurrently**.  
 - **New tasks start** and **interrupt already started ones** before they have reached completion, **instead of executing the tasks sequentially** so each started task needs to reach its end before a new one is started.  




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.9em;' } -->
# What is Multitasking?
 - The tasks share common processing resources such as central processing units **(CPUs)** and **main memory**.
 - Multitasking does not necessarily mean that multiple tasks are executing at exactly the same time. **Multitasking does not imply parallel execution**, but it does mean that more than one task can be **part-way** through execution at the same time, and that **more than one task** is **advancing** over a given period of time.




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is Multithreading?
Multithreading **extends the idea of multitasking** into applications, so you can **subdivide specific operations** within a **single application** into individual threads. Each of the threads can run in **parallel** or/and **concurrently**. The OS **divides processing time** not only among **different applications**, but also among **each thread** within an application.




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# What is Multithreading?
A common example of the **advantage of multithreading** is the fact that you can have a **word processor** that **prints a document** using a background thread, but at the same time another thread is running that **accepts user input**, so that you can type up a new document.




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Summary
**Multitasking** is the **ability of an OS** to run **several tasks**(processes) at the "**same time**".  

Switching between the tasks is so fast that the user can interact fully with the system, **without having to wait for one task to be completely finished** (at least he does not feel like waiting, in practice - he is waiting a couple milliseconds).




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.9em;' } -->
# Summary
**Multithreading** is the **ability of an OS** to execute **different parts of a program**, called threads, **in parallel** and/or **concurrently**.  

Multithreading usually involves very sophisticated programs that use multiple CPUs at the same time to **improve performance and responsiveness**.   

A computer with multiple CPUs which does not have applications written specifically to use multiprocessing or multithreading uses just one CPU.




<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Preemptive multitasking




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.9em;' } -->
# Preemptive multitasking
- In computing, preemption is the act of **temporarily interrupting** a task being carried out by a computer system, **without requiring its cooperation**, and with the intention of **resuming the task** at a later time.
- Such changes of the executed task are known as _**Context switching**_.
- It is normally carried out by a privileged task or part of the system known as a preemptive scheduler, which has the power to preempt, or interrupt, and later resume, other tasks in the system.




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.9em;' } -->
# Context switching
- In computing, a **context switch** is the process of **storing** and **restoring the state** (the execution context) of a **process** or a **thread** so that execution can be resumed from the same point at a later time.  

- This enables multiple processes to share a **single CPU** and is an essential feature of a **multitasking** operating system.




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.9em;' } -->
# Context switching cost
- Context switches are usually **computationally intensive**, and much of the design of OS is to optimize the use of context switches.
- Switching from one process to another requires a certain amount of **time** for doing the administration - **saving** and **loading** registers and memory maps, updating various tables and lists, etc.
- Switching between threads of a single process can be faster than between two separate processes, because threads share the **same virtual memory maps**, so a [TLB](https://en.wikipedia.org/wiki/Translation_lookaside_buffer) flush is not necessary.




<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Cooperative multitasking
## (non-preemptive multitasking)




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.9em;' } -->
# Cooperative multitasking
- Cooperative multitasking is a style of computer multitasking in which the **OS never initiates a context switch** from a running process to another process.
- Instead, processes voluntarily [yield control](https://en.wikipedia.org/wiki/Yield_(multithreading) periodically or when idle in order to enable multiple applications to be run simultaneously.
- All programs must cooperate for the entire scheduling scheme to work.




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.9em;' } -->
# Cooperative multitasking
- As a cooperatively multitasked system relies on _**each process regularly giving up time to other processes**_ on the system, one poorly designed program can consume all of the CPU time for itself, either by performing **extensive calculations** or by **busy waiting**.

- Both would cause the whole system to **hang**. In a server environment, this is a **hazard** that makes the entire environment unacceptably **fragile**.


<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Cooperative multitasking
However, cooperative multitasking allows much **simpler implementation** of applications because their execution is **never unexpectedly interrupted** by the process scheduler.




<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Multithreading use-cases




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.8em;' } -->
# Multithreading use-cases
<br>
The benefits of leveraging multi-threading include:
- Opportunity to **scale** by parallelizing CPU-bound operations.
 - assuming that a multi-core/multi-processor hardware is used.  
- **Perform** CPU-bound **work while** I/O operations are **waiting**.  
- **Maintain a responsive user interface**.
 - farming off lengthy and/or blocking operations to a separate thread.
 - using thread priorities to ensure the UI thread has highest priority.




<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Multithreading caveats




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.8em;' } -->
# Multithreading caveats
The price to pay for multi-threading includes:
- Slower execution time on single-core/processor machines.
 - context-switching overhead

<!-- <img class="slide-image" showInPresentation="true" src="images\Caveats.PNG" style="top:35%; left:1%; width:100%; z-index:-1; border: 1px solid white; border-radius:5px;" /> -->
<br><br><br>
- Added program complexity
 - More lines of code
 - Less readable/maintainable
 - Difficult to debug
 - Difficult to test




// TODO

<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Threads lifetime
## Managed thread objects and OS threads




<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Threads lifetime
- Consider the behavior of the following code:

```cs
if (true)
{
	 new Thread(() =>
	 {
		 ExecuteLongRunningTask();
	 }).Start();
}

while (true)
{
	 //do nothing
	 Thread.Sleep(100);
}
```

- Will the thread be suspended after the GC collects the "Thread" object that is no longer referenced in the execution scope?

<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Threads lifetime
- `Thread` objects will be eligible for garbage collection as soon as they are no more used.
- In our example - after calling the `Start()` method, the `Thread` object will be immediately scheduled for GC. It will however not be collected immediately, as the GC runs at specific times. [Learn more about GC .](http://www.red-gate.com/products/dotnet-development/ants-memory-profiler/learning-memory-management/memory-management-fundamentals)
- However, the actual **OS thread** is not relying on the `Thread` object and will continue to run even if the `Thread` object is collected.







<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->





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
