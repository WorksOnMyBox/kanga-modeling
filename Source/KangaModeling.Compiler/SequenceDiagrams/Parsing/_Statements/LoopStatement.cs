﻿namespace KangaModeling.Compiler.SequenceDiagrams
{
    internal class LoopStatement : Statement
    {
        public LoopStatement(Token keyword, Token guardExpression)
            : base(keyword, guardExpression)
        {
        }

        public Token GuardExpression
        {
            get { return Arguments[0]; }
        }

        public override void Build(IModelBuilder builder)
        {
            builder.StartLoop(Keyword, GuardExpression);
        }
    }
}