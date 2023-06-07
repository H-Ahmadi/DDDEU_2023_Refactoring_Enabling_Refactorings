# Refactoring-Enabling Refactorings Workshop
This is the repository for **Refactoring-Enabling Refactorings** hands-on lab at DDD Europe 2023. This repository contains all the necessary materials and code examples to enhance your learning experience during the workshop.

⚠️The repository is empty right now. The content will be added soon.

## Workshop Details
Title: Refactoring-Enabling Refactorings  
Event: DDD Europe 2023 - Amsterdam  
Duration: 2 Hours  
[Link to the workshop](https://2023.dddeurope.com/program/refactoring-enabling-refactorings/)

## Abstract
Most legacy systems have a strong technical resistance to refactoring. This resistance prevents many legacy systems from being touched. There can be many reasons, including developers' concern about the amount of effort required, or their fear of unexpected consequences. For a large refactoring to be successful, it is essential to overcome this resistance.

This resistance has a variety of aspects. One of them is the large number of changes that must be adapted for refactoring to be applied. Developers may need to spend a lot of time and effort because of this and Furthermore, they may be forced to rely on large rewrites instead of incremental or iterative development.

Unexpected consequences are another aspect. Most Legacy systems don't have a good test suit, if any at all. Developers are thereby exposed to unintended consequences without knowing about them in a concrete manner. Since the code is not testable, they cannot write tests to apply refactoring. It's actually a vicious cycle, since testing is essential to refactoring and placing tests requires you to refactor the code.

There are actually ways to overcome this resistance or at least mitigate its risks. Our goal in this workshop is to explore a set of techniques, guidelines, and approaches to apply the most basic and essential refactoring needed to make the code testable as well as isolate different parts to reduce the impact of future refactoring. This will reduce the resistance of the system to refactoring, both in terms of the size of changes and the fragility of the refactoring.


## Materials

 **Refactoring Mechanics Branches**
 Step-by-step refactoring instructions demonstrated through a set of branches. Each branch represents a specific step in the process. The branches are as follows:
 
|Branch | Description |
|--|--|
| [01-01-Initial](https://github.com/H-Ahmadi/DDDEU_2023_Refactoring_Enabling_Refactorings/tree/01-01-initial)| Problem part used to teach concepts |
| [01-02-breaking-dependencies](https://github.com/H-Ahmadi/DDDEU_2023_Refactoring_Enabling_Refactorings/tree/01-02-breaking-dependencies)| Making the code testable by using dependency breaking techniques|
| [01-03-covering-with-tests](https://github.com/H-Ahmadi/DDDEU_2023_Refactoring_Enabling_Refactorings/tree/01-03-covering-with-tests)| Convering the code with tests (3 approaches: examples, properties, approvals)|
| [01-04-apply-refactoring](https://github.com/H-Ahmadi/DDDEU_2023_Refactoring_Enabling_Refactorings/tree/01-04-apply-refactoring)| Continuing and presenting the whole process with some refactorings)|


 **Exercise**
 The workshop includes an exercise in C# and Java that participants engage in. This repository includes the C# version (This branch: [02-Exercise](https://github.com/H-Ahmadi/DDDEU_2023_Refactoring_Enabling_Refactorings/tree/02-Exercise)), and an external repository contains the Java version ([Link](https://github.com/H-Ahmadi/DDDEU_2023_Refactoring_Enabling_Refactorings_Java)).