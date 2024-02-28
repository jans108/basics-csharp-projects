using LINQSamples;

// Create instance of view model
SamplesViewModel vm = new();

// Call Sample Method
var result = vm.AggregateUsingGroupByMethod();

// Display Results
vm.Display(result);