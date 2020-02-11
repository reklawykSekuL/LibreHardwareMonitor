﻿// Mozilla Public License 2.0
// If a copy of the MPL was not distributed with this file, You can obtain one at http://mozilla.org/MPL/2.0/.
// Copyright (C) LibreHardwareMonitor and Contributors
// All Rights Reserved

using System.Collections.Generic;

namespace LibreHardwareMonitor.Hardware.Memory
{
    internal class MemoryGroup : IGroup
    {
        private readonly Hardware[] _hardware;

        public MemoryGroup(ISettings settings)
        {
            // No implementation for RAM on Unix systems
            if (Software.OperatingSystem.IsLinux)
            {
                _hardware = new Hardware[0];
                return;
            }
            _hardware = new Hardware[] { new GenericMemory("Generic Memory", settings) };
        }

        public string GetReport()
        {
            return null;
        }

        public IEnumerable<IHardware> Hardware => _hardware;

        public void Close()
        {
            foreach (Hardware ram in _hardware)
                ram.Close();
        }
    }
}
