# Асинхронно и паралелно програмиране

# Кратко теоретично въведение   

## Разлика между Процес и Нишка (обем работа, памет)  

### Какво е Процес?  

Един **процес** представлява **инстанция на компютърна програма, в момента на изпълнението й**. Съдържа програмния код и текущото състояние на програмата. В зависимост от операционната система и възможностите на хардуера - един процес, може да бъде съставен от множество работни **нишки**, които изпълняват инструкции **асинхронно**.  

Една **пасивна** колекция от инструкции се нарича **КОМПЮТЪРНА ПРОГРАМА**, а **програма в хода си на изпълнение** се нарича **ПРОЦЕС**. Множество процеси могат да бъдат асоциирани с една и съща компютърна програма. Например, можем да отворим 2,3,4 или повече инстанции на Visual Studio. Това са няколко **различни** процеса, които са стартирани от **една и съща** компютърна програма.

### Какво е Нишка?  

## Разлика между Многозадачност и Многонишковост  
Multitasking
The ability to run several programs simultaneously, potentially by utilizing several processors, but predominantly, by time-sharing their resource requirements.

An example is right on your desktop, where you may have a web browser, e-mail client, audio player, word processor, spreadsheet and who knows what else on the air at the same time. They can dance in and out of having the processor to themselves many times per second, because neither of them needs all of it for very long at a time.

Multithreading
The ability to run several functions of a single program simultaneously, predominantly by utilizing several processors, but potentially, by time-sharing their resource requirements.

An example would be a web server, where the responses to all the incoming requests need much of the same program logic and state, but different handles on a few things (network socket, id of caller, whatever else). Sharing the greater bunch of the data pertaining to the program, but having dedicated copies of a small amount of private things, lets threads be spawned and destroyed very quickly, and permits an increase in available processing power to increase the number of requests answered without requiring an additional copies of the server program to be running.

These are largely two sides of the same coin, the difference in vocabulary is mainly down to entire programs (processes) being a larger unit of stored state, with a correspondingly higher workload required to shift it around between processors and/or memory.

Both of them require some O/S scheduling mechanism to keep track of which process/thread goes next, goes where and goes when, but the differences in the cost of manipulating processes and threads means that the best policy for one isn't necessarily good for the other. Hence, they get different names, and can be discussed as different things, within a context implied by the word chosen presently.

!!!
It’s important to note that a thread can do anything a process can do. But since a process can consist of multiple threads, a thread could be considered a ‘lightweight’ process. Thus, the essential difference between a thread and a process is the work that each one is used to accomplish. Threads are used for small tasks, whereas processes are used for more ‘heavyweight’ tasks – basically the execution of applications.

Another difference between a thread and a process is that threads within the same process share the same address space, whereas different processes do not. This allows threads to read from and write to the same data structures and variables, and also facilitates communication between threads. Communication between processes – also known as IPC, or inter-process communication – is quite difficult and resource-intensive.

A common example of the advantages of multithreading is the fact that you can have a word processor that prints a document using a background thread, but at the same time another thread is running that accepts user input, so that you can type up a new document.

If we were dealing with an application that uses only one thread, then the application would only be able to do one thing at a time – so printing and responding to user input at the same time would not be possible in a single threaded application.

Each process has it’s own address space, but the threads within the same process share that address space. Threads also share any other resources within that process. This means that it’s very easy to share data amongst threads, but it’s also easy for the threads to step on each other, which can lead to bad things.

Multithreaded programs must be carefully programmed to prevent those bad things from happening. Sections of code that modify data structures shared by multiple threads are called critical sections. When a critical section is running in one thread it’s extremely important that no other thread be allowed into that critical section. This is called synchronization, which we wont get into any further over here. But, the point is that multithreading requires careful programming.

### Какво е Многозадачност?  

### Какво е Многонишковост?  

## Какво представлява Асинхронното програмиране?  

### Ползи и недостатъци  

## Какво представлява Паралелното програмиране?  

### Ползи и недостатъци  

# Демо 1 (Еднонишково приложение)  

# Демо 2 (Многонишково приложение)  

# Демо 3 (Многонишково приложение на един процесор)  

# Демо 4 (Многонишково приложение на множество процесори)  

# Кога да се възползваме от многонишково програмиране  
