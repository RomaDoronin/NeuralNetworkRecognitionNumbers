@echo off

if not exist bin (
	mkdir bin
)

%1\csc /target:winexe /out:bin/NeuralNetworkRecognitionNumbers.exe *.cs