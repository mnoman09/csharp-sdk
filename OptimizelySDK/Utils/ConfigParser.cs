﻿/* 
 * Copyright 2017, Optimizely
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimizelySDK.Utils
{
    public static class ConfigParser<T> where T : ICloneable
    {
        /// <summary>
        /// Creates a map (associative array) that maps to a list of entities
        /// </summary>
        /// <param name="entities">The list of entities which will be the "values" of the associative array</param>
        /// <param name="getKey">A function to return the key value from the entity</param>
        /// <param name="clone">Whether or not to clone the original entity</param>
        /// <returns>associative array of key => entity</returns>
        public static Dictionary<string, T> GenerateMap(IEnumerable<T> entities, Func<T, string> getKey, bool clone)
        {
            return entities.ToDictionary(e => getKey(e), e => clone ? (T)e.Clone() : e);
        }

        /// <summary>
        /// Creates an array of entities from the entity
        /// (not sure this is really needed)
        /// </summary>
        /// <param name="entities">Original Entities</param>
        /// <param name="clone">Whether or not to clone the original entity</param>
        /// <returns>array of entities</returns>
        public static T[] GenerateMap(IEnumerable<T> entities, bool clone)
        {
            return entities.Select(e => clone ? (T)e.Clone() : e).ToArray();
        }
    }
}