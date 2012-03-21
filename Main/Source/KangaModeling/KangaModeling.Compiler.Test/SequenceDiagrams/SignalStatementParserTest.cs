﻿using System;
using System.Linq;
using KangaModeling.Compiler.SequenceDiagrams;
using NUnit.Framework;
using KangaModeling.Compiler.Test.SequenceDiagrams.Helper;

namespace KangaModeling.Compiler.Test.SequenceDiagrams
{
    [TestFixture]
    public class SignalStatementParserTest
    {
        [TestCase("A->B", new[]{typeof(FindOrCreateParticipantStatement), typeof(FindOrCreateParticipantStatement), typeof(CallSignalStatement)})]
        [TestCase("A-->B", new[] { typeof(FindOrCreateParticipantStatement), typeof(FindOrCreateParticipantStatement), typeof(ReturnSignalStatement) })]
        [TestCase("A<-B", new[] { typeof(FindOrCreateParticipantStatement), typeof(FindOrCreateParticipantStatement), typeof(CallSignalStatement) })]
        [TestCase("A<--B", new[] { typeof(FindOrCreateParticipantStatement), typeof(FindOrCreateParticipantStatement), typeof(ReturnSignalStatement) })]

        [TestCase("->B", new[] { typeof(MissingArgumentStatement), typeof(FindOrCreateParticipantStatement), typeof(CallSignalStatement) })]
        [TestCase("-->B", new[] { typeof(MissingArgumentStatement), typeof(FindOrCreateParticipantStatement), typeof(ReturnSignalStatement) })]
        [TestCase("<-B", new[] { typeof(MissingArgumentStatement), typeof(FindOrCreateParticipantStatement), typeof(CallSignalStatement) })]
        [TestCase("<--B", new[] { typeof(MissingArgumentStatement), typeof(FindOrCreateParticipantStatement), typeof(ReturnSignalStatement) })]

        [TestCase("A->", new[] { typeof(FindOrCreateParticipantStatement), typeof(MissingArgumentStatement), typeof(CallSignalStatement) })]
        [TestCase("A-->", new[] { typeof(FindOrCreateParticipantStatement), typeof(MissingArgumentStatement), typeof(ReturnSignalStatement) })]
        [TestCase("A<-", new[] { typeof(FindOrCreateParticipantStatement), typeof(MissingArgumentStatement), typeof(CallSignalStatement) })]
        [TestCase("A<--", new[] { typeof(FindOrCreateParticipantStatement), typeof(MissingArgumentStatement), typeof(ReturnSignalStatement) })]

        [TestCase("A->B : text", new[] { typeof(FindOrCreateParticipantStatement), typeof(FindOrCreateParticipantStatement), typeof(CallSignalStatement) })]
        [TestCase("A-->B : text", new[] { typeof(FindOrCreateParticipantStatement), typeof(FindOrCreateParticipantStatement), typeof(ReturnSignalStatement) })]
        [TestCase("A<-B : text", new[] { typeof(FindOrCreateParticipantStatement), typeof(FindOrCreateParticipantStatement), typeof(CallSignalStatement) })]
        [TestCase("A<--B : text", new[] { typeof(FindOrCreateParticipantStatement), typeof(FindOrCreateParticipantStatement), typeof(ReturnSignalStatement) })]

        [TestCase("A->: text", new[] { typeof(FindOrCreateParticipantStatement), typeof(MissingArgumentStatement), typeof(CallSignalStatement) })]
        [TestCase("A-->: text", new[] { typeof(FindOrCreateParticipantStatement), typeof(MissingArgumentStatement), typeof(ReturnSignalStatement) })]
        [TestCase("A<-: text", new[] { typeof(FindOrCreateParticipantStatement), typeof(MissingArgumentStatement), typeof(CallSignalStatement) })]
        [TestCase("A<--: text", new[] { typeof(FindOrCreateParticipantStatement), typeof(MissingArgumentStatement), typeof(ReturnSignalStatement) })]

        [TestCase("->B: text", new[] { typeof(MissingArgumentStatement), typeof(FindOrCreateParticipantStatement), typeof(CallSignalStatement) })]
        [TestCase("-->B: text", new[] { typeof(MissingArgumentStatement), typeof(FindOrCreateParticipantStatement), typeof(ReturnSignalStatement) })]
        [TestCase("<-B: text", new[] { typeof(MissingArgumentStatement), typeof(FindOrCreateParticipantStatement), typeof(CallSignalStatement) })]
        [TestCase("<--B: text", new[] { typeof(MissingArgumentStatement), typeof(FindOrCreateParticipantStatement), typeof(ReturnSignalStatement) })]

        [TestCase("A<-->B: text", new[] {typeof(FindOrCreateParticipantStatement), typeof(FindOrCreateParticipantStatement), typeof(UnknownStatement)})]
        [TestCase("skdjskdj: text", new[] { typeof(MissingArgumentStatement), typeof(MissingArgumentStatement), typeof(UnknownStatement) })]
        [TestCase("----->", new[] { typeof(MissingArgumentStatement), typeof(MissingArgumentStatement), typeof(UnknownStatement) })]
        public void ParseTest(string input, Type[] expectedStatementTypes)
        {
            var target = new SignalStatementParser();
            var actualStatementTypes = target.Parse(input).Select(statement=> statement.GetType());
            CollectionAssert.AreEquivalent(expectedStatementTypes, actualStatementTypes);
        }

        [Ignore]
        public void EnsureTokensSimple(string input, string[] expectedTokenValues)
        {
            var target = new SignalStatementParser();
            var actual = target.Parse(input);
            var actualTokenvalues = actual.SelectMany(statement=>statement.Tokens()).Select(token => token.Value);
            CollectionAssert.AreEquivalent(expectedTokenValues, actualTokenvalues);
        }
    }
}