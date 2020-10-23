﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using PixiEditor.Exceptions;
using PixiEditor.Helpers.Extensions;
using PixiEditor.Models.Position;

namespace PixiEditor.Models.DataHolders
{
    public struct BitmapPixelChanges
    {
        public BitmapPixelChanges(Dictionary<Coordinates, Color> changedPixels)
        {
            ChangedPixels = changedPixels;
            WasBuiltAsSingleColored = false;
        }

        public static BitmapPixelChanges Empty => new BitmapPixelChanges(new Dictionary<Coordinates, Color>());

        public bool WasBuiltAsSingleColored { get; private set; }

        public Dictionary<Coordinates, Color> ChangedPixels { get; set; }

        /// <summary>
        ///     Builds BitmapPixelChanges with only one color for specified coordinates.
        /// </summary>
        /// <returns>Single-colored BitmapPixelChanges.</returns>
        public static BitmapPixelChanges FromSingleColoredArray(IEnumerable<Coordinates> coordinates, Color color)
        {
            Dictionary<Coordinates, Color> dict = new Dictionary<Coordinates, Color>();
            foreach (Coordinates coordinate in coordinates)
            {
                dict.Add(coordinate, color);
            }

            return new BitmapPixelChanges(dict) { WasBuiltAsSingleColored = true };
        }

        /// <summary>
        ///     Combines pixel changes array with overriding values.
        /// </summary>
        /// <param name="changes">BitmapPixelChanges to combine.</param>
        /// <returns>Combined BitmapPixelChanges.</returns>
        public static BitmapPixelChanges CombineOverride(BitmapPixelChanges[] changes)
        {
            if (changes == null || changes.Length == 0)
            {
                throw new ArgumentException();
            }

            BitmapPixelChanges output = Empty;

            for (int i = 0; i < changes.Length; i++)
            {
                output.ChangedPixels.AddRangeOverride(changes[i].ChangedPixels);
            }

            return output;
        }

        /// <summary>
        ///     Builds BitmapPixelChanges using 2 same-length enumerables of coordinates and colors.
        /// </summary>
        public static BitmapPixelChanges FromArrays(IEnumerable<Coordinates> coordinates, IEnumerable<Color> color)
        {
            Coordinates[] coordinateArray = coordinates.ToArray();
            Color[] colorArray = color.ToArray();
            if (coordinateArray.Length != colorArray.Length)
            {
                throw new ArrayLengthMismatchException();
            }

            Dictionary<Coordinates, Color> dict = new Dictionary<Coordinates, Color>();
            for (int i = 0; i < coordinateArray.Length; i++)
            {
                dict.Add(coordinateArray[i], colorArray[i]);
            }

            return new BitmapPixelChanges(dict);
        }
    }
}