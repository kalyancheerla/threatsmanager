﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using PostSharp.Patterns.Contracts;
using ThreatsManager.Interfaces;
using ThreatsManager.Interfaces.ObjectModel;
using ThreatsManager.Interfaces.ObjectModel.Diagrams;
using ThreatsManager.Interfaces.ObjectModel.Entities;
using ThreatsManager.Interfaces.ObjectModel.Properties;
using ThreatsManager.Utilities;
using ThreatsManager.Utilities.Aspects;
using ThreatsManager.Utilities.Aspects.Engine;

namespace ThreatsManager.Engine.ObjectModel.Diagrams
{
#pragma warning disable CS0067
    [JsonObject(MemberSerialization.OptIn)]
    [Serializable]
    [SimpleNotifyPropertyChanged]
    [AutoDirty]
    [DirtyAspect]
    [ThreatModelChildAspect]
    [PropertiesContainerAspect]
    public class GroupShape : IGroupShape, IThreatModelChild, IInitializableObject
    {
        public GroupShape()
        {

        }

        public GroupShape([NotNull] IThreatModel model, [NotNull] IGroup group) : this()
        {
            _modelId = model.Id;
            _model = model;
            _group = group;
            _associatedId = group.Id;
        }

        public bool IsInitialized => Model != null && _associatedId != Guid.Empty;

        #region Specific implementation.
        public Scope PropertiesScope => Scope.GroupShape;

        private IGroup _group;

        [JsonProperty("id")]
        private Guid _associatedId;

        public Guid AssociatedId => _associatedId;

        [InitializationRequired]
        public IIdentity Identity => _group ?? (_group = Model?.GetGroup(_associatedId));

        [JsonProperty("pos")]
        public PointF Position { get; set; }

        [JsonProperty("size")]
        public SizeF Size { get; set; }

        public IGroupShape Clone([NotNull] IGroupShapesContainer container)
        {
            GroupShape result = null;
            if (container is IThreatModelChild child && child.Model is IThreatModel model)
            {
                result = new GroupShape()
                {
                    _associatedId = _associatedId,
                    _model = model,
                    _modelId = model.Id,
                    Position = new PointF(Position.X, Position.Y),
                    Size = new SizeF(Size)
                };
                this.CloneProperties(result);

                container.Add(result);
            }

            return result;
        }
        #endregion

        #region Additional placeholders required.
        protected Guid _modelId { get; set; }
        protected IThreatModel _model { get; set; }
        private IPropertiesContainer PropertiesContainer => this;
        private List<IProperty> _properties { get; set; }
        #endregion

        #region Default implementation.
        public IThreatModel Model { get; }

        public event Action<IPropertiesContainer, IProperty> PropertyAdded;
        public event Action<IPropertiesContainer, IProperty> PropertyRemoved;
        public event Action<IPropertiesContainer, IProperty> PropertyValueChanged;
        public bool HasProperty(IPropertyType propertyType)
        {
            return false;
        }
        public IEnumerable<IProperty> Properties { get; }
        public IProperty GetProperty(IPropertyType propertyType)
        {
            return null;
        }

        public IProperty AddProperty(IPropertyType propertyType, string value)
        {
            return null;
        }

        public bool RemoveProperty(IPropertyType propertyType)
        {
            return false;
        }

        public bool RemoveProperty(Guid propertyTypeId)
        {
            return false;
        }

        public void ClearProperties()
        {
        }

        public void Apply(IPropertySchema schema)
        {
        }

        public event Action<IDirty, bool> DirtyChanged;
        public bool IsDirty { get; }
        public void SetDirty()
        {
        }

        public void ResetDirty()
        {
        }

        public bool IsDirtySuspended { get; }
        public void SuspendDirty()
        {
        }

        public void ResumeDirty()
        {
        }
        #endregion
    }
}
