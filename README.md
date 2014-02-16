# Automated Testing Challenge

A demo application that contains a deliberately poorly-written application
that's meant to mimic a real-world "legacy" application that's been dropped
on your lap, has absolutely no documentation, and the developer that 
originally created it was fired and is no longer reachable.  But, you've
still got to support it anyway.


## The Challenge
Try to do the following:

1. Run the application and see what it does
2. Reverse-engineer some set of features/requirements
3. Create automated tests that validate/verify those requirements
4. Implement the features detailed below (complete with tests)


## The Features
Once you've completed steps 1-3 above, implement the following features (one at a time).

### Add a client

### Support XML data files

### Import/save data into database


### [More features TBD]


The Concepts
------------
This application employs some commonplace practices that are particularly 
difficult to test, particularly in an automated/continuous build environment.
Practices such as:

- Tightly-coupled UI & application logic
- File system access
- Database access
- Depending/assuming certain environmental configuration (e.g. specific file path)
- Referencing current time (i.e. DateTime.Now)
- Static/god object (e.g. HttpContext)
- In-line service instantiation
