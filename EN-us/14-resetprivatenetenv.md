# NEO Blockchain Quick Start Guide for .NET Developers

[NEO Blockchain C# Developers Center of Excellence](https://github.com/mwherman2000/neo-csharpcoe/blob/master/README.md)

The `neo-csharpcoe` project is an "umbrella" project for several initiatives related to providing tools and libraries (code), frameworks, how-to documentation, and best practices for enterprise application development using .NET/C#, C#.NEO and the NEO Blockchain software platform.

The `neo-csharpcoe` is an independent, free, open source project that is 100% community-supported by people like yourself through your contributions of time, energy, passion, promotion, and donations.  

To learn more about contributing to the `neo-csharpcoe`, click [here](https://github.com/mwherman2000/neo-csharpcoe/blob/master/CONTRIBUTE.md).

## Appendix C - Reset NEO privatenet Environment: Container, Wallets, and Clients

### Purpose

The purpose of this section is to document how to reset your NEO privatenet environment: container and clients; for example, when you run out of gas.

### Goals, Non-Goals and Assumptions

* Being able to reset your NEO privatenet environment as quickly as possible

### Principles

* Provide reliable documentation: timely, accurate, visual, and complete
* Save as much of a person's time as possible
* Use open source software whenever possible

### Drivers

* Need in the NEO .NET developer community to have concise and easy-to-follow documentation to enable people to get up to speed developing NEO smart contracts in as short a time as possible

## Stop all of your NEO Client apps

1. Stop all of your NEO client apps that may be using the NEO Docker container (e.g. neo-cli, neo-gui, ...).

## Reset your NEO privatenet Docker container

2. Reset the the NEO Docker container by running the following script: 
    ```
    docker container list
    docker stop neo-privnet-with-gas
    docker container list
    docker rm neo-privnet-with-gas
    docker container list
    docker run -d --name neo-privnet-with-gas -p 20333-20336:20333-20336/tcp -p 30333-30336:30333-30336/tcp cityofzion/neo-privnet-with-gas
    docker container list
    pause
    ```
    Script: NEO Docker Restart ([./scripts/neodockerreset.bat.txt](./scripts/neodockerreset.bat.txt))

## Reset your NEO privatenet wallets

3. Delete all of your wallets you used with the NEO privatenet. They will need to be recreated anyway.

**NOTE:** **Be very careful** to only delete wallets used with the NEO **privatenet** - *not your mainnet wallets*.

**NOTE:** Rather than delete your wallet files, consider moving them to a subfolder (e.g. folder `wallets-old`).

## Reset your NEO privatenet clients

4. Delete all of your client app's blockchain database folders.
5. Delete all of your client app's `peers.dat` files.
6. If it is a Visual Studio development project, delete the entire `bin/Debug` folder.

## Start your NEO privatenet client apps

7. After the preceding tasks are complete, the reset is complete. You can rebuild/start your NEO privatenet client apps.

## Script Library

* NEO Docker Download/Install/Run ([./scripts/neodockerinstall.bat.txt](./scripts/neodockerinstall.bat.txt))
* NEO Docker Stop/Remove ([./scripts/neodockeruninstall.bat.txt](./scripts/neodockeruninstall.bat.txt))
* NEO Docker Start ([./scripts/neodockerstart.bat.txt](./scripts/neodockerstart.bat.txt))
* NEO Docker Stop ([./scripts/neodockerstop.bat.txt](./scripts/neodockerstop.bat.txt))
* NEO Docker Restart ([./scripts/neodockerrestart.bat.txt](./scripts/neodockerrestart.bat.txt))
* NEO Docker Reset ([./scripts/neodockerreset.bat.txt](./scripts/neodockerreset.bat.txt)
* NEO Docker Python CLI/Shell ([./scripts/neodockerpshell.bat.txt](./scripts/neodockerpshell.bat.txt))

## References

* N/A
