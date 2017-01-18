# WMIWatcher
Tool for remote watching, data capture and managing Windows machines via WMI

This tool is able to capture data, watch some important events and manage multiple remote computers.
Usage:
1)Select targets;
2)Insert login/password of account with administrative rights;
3)Select DCOM authentication/impersonation level;
4)Get data/Start real-time monitoring/Create constant consumer for logging;

Attention!
Don't delete/manage database file while working! Logging based on WMI constant consumers, where each logger is a constant consumer, registered via EventService on target PC.
