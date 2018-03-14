﻿#region License

/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

#endregion

using System;

namespace Gremlin.Net.IntegrationTest.Gherkin
{
    /// <summary>
    /// Represents a test exception that should be ignored, given a reason (ie: feature not supported in the .NET GLV)
    /// </summary>
    public class IgnoreException : Exception
    {
        public IgnoreException(IgnoreReason reason) : base(GetMessage(reason))
        {
            
        }

        private static string GetMessage(IgnoreReason reason)
        {
            string reasonSuffix = null;
            switch (reason)
            {
                case IgnoreReason.PWithinWrapsArgumentsInArray:
                    reasonSuffix = " because P.Within() arguments are incorrectly wrapped in an array (TINKERPOP-1920)";
                    break;
                case IgnoreReason.PNotDeserializationProblem:
                    reasonSuffix = " because P.Not() cannot be deserialized by Gremlin Server (TINKERPOP-1922)";
                    break;
            }
            return $"Scenario ignored" + reasonSuffix;
        }
    }
    
    public enum IgnoreReason
    {
        PWithinWrapsArgumentsInArray,
        PNotDeserializationProblem
    }
}