# Multithreaded programming fundamentals

[Presentation Slides](https://cdn.rawgit.com/InKolev/Async-And-Parallel-Programming/master/1.%20Multithreaded%20Programming%20Fundamentals/index.html)

## Multitasking
The ability to run several programs simultaneously, potentially by utilizing several processors, but predominantly, by time-sharing their resource requirements.

An example is right on your desktop, where you may have a web browser, e-mail client, audio player, word processor, spreadsheet and who knows what else on the air at the same time. They can dance in and out of having the processor to themselves many times per second, because neither of them needs all of it for very long at a time.

## Multithreading
The ability to run several functions of a single program simultaneously, predominantly by utilizing several processors, but potentially, by time-sharing their resource requirements.

An example would be a web server, where the responses to all the incoming requests need much of the same program logic and state, but different handles on a few things (network socket, id of caller, whatever else). Sharing the greater bunch of the data pertaining to the program, but having dedicated copies of a small amount of private things, lets threads be spawned and destroyed very quickly, and permits an increase in available processing power to increase the number of requests answered without requiring an additional copies of the server program to be running.

These are largely two sides of the same coin, the difference in vocabulary is mainly down to entire programs (processes) being a larger unit of stored state, with a correspondingly higher workload required to shift it around between processors and/or memory.

Both of them require some O/S scheduling mechanism to keep track of which process/thread goes next, goes where and goes when, but the differences in the cost of manipulating processes and threads means that the best policy for one isn't necessarily good for the other. Hence, they get different names, and can be discussed as different things, within a context implied by the word chosen presently.

A common example of the advantages of multithreading is the fact that you can have a word processor that prints a document using a background thread, but at the same time another thread is running that accepts user input, so that you can type up a new document.

If we were dealing with an application that uses only one thread, then the application would only be able to do one thing at a time – so printing and responding to user input at the same time would not be possible in a single threaded application.

Each process has it’s own address space, but the threads within the same process share that address space. Threads also share any other resources within that process. This means that it’s very easy to share data amongst threads, but it’s also easy for the threads to step on each other, which can lead to bad things like corrupted data and so on.

Multithreaded programs must be carefully programmed to prevent those bad things from happening. Sections of code that modify data structures shared by multiple threads are called critical sections. When a critical section is running in one thread it’s extremely important that no other thread be allowed into that critical section. This is called synchronization, which we wont get into any further over here. But, the point is that multithreading requires careful programming.

## Asynchronous programming
Async operations are simply non-blocking.  
Asynchronous only means that events are triggered outside the main course of execution, so that while an operation is executed, the main thread does not freeze.  

Asynchonous programming solves the problem of waiting around for an expensive operation to complete before you can do anything else. If you can get other stuff done while you're waiting for the operation to complete then that's a good thing. Example: keeping a UI running while you go and retrieve more data from a web service.

Visual representation of Async, Parallel and Concurrent execution: http://urda.cc/blog/2010/10/04/asynchronous-versus-parallel-programming

## Concurrent programming
In concurrent computation two computations both advance independently of each other. The second computation doesn't have to wait until the first is finished for it to advance. It doesn't state however, the mechanism how this is achieved. In single-core setup, suspending and alternating between threads is required (also called pre-emptive multithreading).

In parallel computation two computations both advance simultaneously - that is literally at the same time. This is not possible with single CPU (unless the single processor supports hyperthreading) and requires multi-core setup instead.
