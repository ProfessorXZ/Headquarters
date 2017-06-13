﻿using HQ.Interfaces;
using System;
using System.Collections.Generic;
using HQ.Extensions;

namespace HQ.Parsing.IObjectConverters
{
    /// <summary>
    /// Converts a string or string[] to an int[]
    /// </summary>
    public class IntArrayObjectConverter : IObjectConverter
    {
        /// <inheritdoc/>
        public Type ConversionType => typeof(int[]);

        /// <inheritdoc/>
        public object ConvertFromArray<T>(string[] arguments, T context)
        {
            int[] array = new int[arguments.Length];

            for (int i = 0; i < arguments.Length; i++)
            {
                if (!int.TryParse(arguments[i], out int res))
                {
                    return null;
                }
                array[i] = res;
            }

            return array;
        }

        /// <inheritdoc/>
        public object ConvertFromString<T>(string argument, T context)
        {
            List<string> arguments = argument.Explode();
            int[] array = new int[arguments.Count];

            for (int i = 0; i < arguments.Count; i++)
            {
                if (!int.TryParse(arguments[i], out int res))
                {
                    return null;
                }
                array[i] = res;
            }

            return array;
        }
    }
}
