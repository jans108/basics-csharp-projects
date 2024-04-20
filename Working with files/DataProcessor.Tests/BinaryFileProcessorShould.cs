using System.IO.Abstractions.TestingHelpers;

namespace DataProcessor.Tests;

public class BinaryFileProcessorShould
{
    [Fact]
    public void AddLargestNumber()
    {
        var mockInputFile = new MockFileData(new byte[] { 0xFF, 0x34, 0x56, 0xD2 });
        var mockFileSystem = new MockFileSystem();
        mockFileSystem.AddFile(@"c:\root\in\myfile.txt", mockInputFile);
        mockFileSystem.AddDirectory(@"c:\root\out");

        var sut = new BinaryFileProcessor(@"c:\root\in\myfile.txt",
                                          @"c:\root\out\myfile.txt",
                                          mockFileSystem);

        sut.Process();

        Assert.True(mockFileSystem.FileExists(@"c:\root\in\myfile.txt"));

        var processedFile = mockFileSystem.GetFile(@"c:\root\out\myfile.txt");

        byte[] data = processedFile.Contents;

        Assert.Equal(5, data.Length);
        Assert.Equal(0xFF, data[4]);
    }
}