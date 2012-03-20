﻿using System.Collections.Generic;

namespace KangaModeling.Compiler.SequenceDiagrams
{
    internal abstract class ParticipantStatement : Statement
    {
        private readonly Token m_Name;

        protected ParticipantStatement(Token keyword, Token name) 
            : base(keyword)
        {
            m_Name = name;
        }

        public override void Build(AstBuilder builder)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Token> Tokens()
        {
            return base.Tokens()
                .Append(m_Name);
        }
    }
}
