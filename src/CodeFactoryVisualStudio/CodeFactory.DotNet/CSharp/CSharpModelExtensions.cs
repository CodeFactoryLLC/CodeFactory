//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Extension class that manages extensions for the c# models.
    /// </summary>
    public static class CSharpModelExtensions
    {
        /// <summary>
        /// Extension method that converts a C# model into a target C# model format. If the cast does not apply then a null will be returned.
        /// </summary>
        /// <typeparam name="T">The target type of model to return.</typeparam>
        /// <param name="source">The source model to transform.</param>
        /// <returns>The c# model cast to the target type or null if the cast is invalid.</returns>
        public static T ToModel<T>(this CsModel source) where T : class, ICsModel
        {
            return source as T;
        }

        /// <summary>
        /// Iterator that returns <see cref="CsClass"/> models from an enumeration of <see cref="ICsContainer"/>
        /// </summary>
        /// <param name="source">The source container to iterate over.</param>
        /// <returns>The iterator to be executed.</returns>
        public static IEnumerable<CsClass> ClassIterator(this IEnumerable<CsContainer> source)
        {
            if (source == null) yield break;
            foreach (var csContainer in source)
            {
                if (csContainer == null) continue;
                if (csContainer.ContainerType != CsContainerType.Class) continue;

                if (csContainer is CsClass model) yield return model;
            }
        }

        /// <summary>
        /// Iterator that returns <see cref="CsInterface"/> models from an enumeration of <see cref="ICsContainer"/>
        /// </summary>
        /// <param name="source">The source container to iterate over.</param>
        /// <returns>The iterator to be executed.</returns>
        public static IEnumerable<CsInterface> InterfaceIterator(this IEnumerable<CsContainer> source)
        {
            if (source == null) yield break;
            foreach (var csContainer in source)
            {
                if (csContainer == null) continue;
                if (csContainer.ContainerType != CsContainerType.Interface) continue;

                if (csContainer is CsInterface model) yield return model;
            }
        }

        /// <summary>
        /// Iterator that returns <see cref="CsStructure"/> models from an enumeration of <see cref="ICsContainer"/>
        /// </summary>
        /// <param name="source">The source container to iterate over.</param>
        /// <returns>The iterator to be executed.</returns>
        public static IEnumerable<CsStructure> StructureIterator(this IEnumerable<CsContainer> source)
        {
            if (source == null) yield break;
            foreach (var csContainer in source)
            {
                if (csContainer == null) continue;
                if (csContainer.ContainerType != CsContainerType.Structure) continue;

                if (csContainer is CsStructure model) yield return model;
            }
        }

        /// <summary>
        /// Iterator that returns <see cref="CsEvent"/> models from an enumeration of <see cref="ICsMember"/>
        /// </summary>
        /// <param name="source">The source container to iterate over.</param>
        /// <returns>The iterator to be executed.</returns>
        public static IEnumerable<CsEvent> EventIterator(this IEnumerable<CsMember> source)
        {
            if (source == null) yield break;
            foreach (var csMember in source)
            {
                if (csMember == null) continue;
                if (csMember.MemberType != CsMemberType.Event) continue;

                if (csMember is CsEvent model) yield return model;
            }
        }

        /// <summary>
        /// Iterator that returns <see cref="ICsField"/> models from an enumeration of <see cref="ICsMember"/>
        /// </summary>
        /// <param name="source">The source container to iterate over.</param>
        /// <returns>The iterator to be executed.</returns>
        public static IEnumerable<CsField> FieldIterator(this IEnumerable<CsMember> source)
        {
            if (source == null) yield break;
            foreach (var csMember in source)
            {
                if (csMember == null) continue;
                if (csMember.MemberType != CsMemberType.Field) continue;

                if (csMember is CsField model) yield return model;
            }
        }


        /// <summary>
        /// Iterator that returns <see cref="CsMethod"/> models from an enumeration of <see cref="CsMember"/>
        /// </summary>
        /// <param name="source">The source container to iterate over.</param>
        /// <returns>The iterator to be executed.</returns>
        public static IEnumerable<CsMethod> MethodIterator(this IEnumerable<CsMember> source)
        {
            if (source == null) yield break;
            foreach (var csMember in source)
            {
                if (csMember == null) continue;
                if (csMember.MemberType != CsMemberType.Method) continue;

                if (csMember is CsMethod model) yield return model;
            }
        }

        /// <summary>
        /// Iterator that returns <see cref="CsProperty"/> models from an enumeration of <see cref="CsMember"/>
        /// </summary>
        /// <param name="source">The source container to iterate over.</param>
        /// <returns>The iterator to be executed.</returns>
        public static IEnumerable<CsProperty> PropertyIterator(this IEnumerable<CsMember> source)
        {
            if (source == null) yield break;
            foreach (var csMember in source)
            {
                if (csMember == null) continue;
                if (csMember.MemberType != CsMemberType.Property) continue;

                if (csMember is CsProperty model) yield return model;
            }
        }

        /// <summary>
        /// Iterator that returns the target model type from an enumeration of <see cref="ICsModel"/>
        /// </summary>
        /// <typeparam name="T">The target type of model to return.</typeparam>
        /// <param name="source">The source container to iterate over.</param>
        /// <returns>The iterator to be executed.</returns>
        public static IEnumerable<T> ModelIterator<T>(this IEnumerable<CsModel> source) where T:class,ICsModel
        {
            if (source == null) yield break;
            foreach (var csModel in source)
            {
                switch (csModel)
                {
                    case null:
                        continue;
                    case T model:
                        yield return model;
                        break;
                }
            }
        }


    }
}
