package com.mrm.aoc.twentytwo.Day01;

public class Part1 {
    private String rawInput;

    public String getRawInput(){
        return rawInput;
    }

    public void setRawInput(String value){
        rawInput = value;
    }

    public void Solve() {
        String[] inputValues = rawInput.split("\r\n");

        for(String inputValue: inputValues) {
            System.out.println(inputValue);
        }
    }
}
